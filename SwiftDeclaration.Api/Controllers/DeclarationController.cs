using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;
using SwiftDeclaration.Application.Declarations.Commands.RemoveDeclaration;
using SwiftDeclaration.Application.Declarations.Commands.UpdateDeclaration;
using SwiftDeclaration.Application.Declarations.Dtos;
using SwiftDeclaration.Application.Declarations.Queries.GetAllDeclarationsBriefDetails;
using SwiftDeclaration.Application.Declarations.Queries.GetDeclarationById;
using SwiftDeclaration.Infrastructure.Models;

namespace SwiftDeclaration.Api.Controllers;
[Route("api/v1/declarations")]
[ApiController]
public class DeclarationController : ControllerBase
{
    private readonly ISender _mediator;

    public DeclarationController(ISender mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> AddDeclaration([FromForm] AddDeclarationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateDeclaration([FromForm] UpdateDeclarationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{declarationId}")]
    public async Task<IActionResult> RemoveDeclaration(int declarationId)
    {
        await _mediator.Send(new RemoveDeclarationCommand(declarationId));
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDeclarationById(int id)
    {
        var result = await _mediator.Send(new GetDeclarationByIdQuery(id));
        return Ok(HttpResult.Ok(result.Adapt<DeclarationDto>()));
    }

    [HttpGet("brief-details")]
    public async Task<IActionResult> GetAllDeclarationsBriefDetails(string headline = "")
    {
        var result = await _mediator.Send(new GetAllDeclarationsBriefDetailsQuery(headline));
        return Ok(HttpResult.Ok(result));
    }

}
