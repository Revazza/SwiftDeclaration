using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;
using SwiftDeclaration.Application.Declarations.Commands.UpdateDeclaration;

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


    [HttpPut]
    public async Task<IActionResult> UpdateDeclaration([FromForm] UpdateDeclarationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}
