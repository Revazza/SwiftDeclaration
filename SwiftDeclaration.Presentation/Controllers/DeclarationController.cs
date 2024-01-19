using Microsoft.AspNetCore.Mvc;
using SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;
using SwiftDeclaration.Application.Declarations.Queries.GetAllDeclarationsBriefDetails;
using SwiftDeclaration.Infrastructure.Models;
using SwiftDeclaration.Presentation.Services;

namespace SwiftDeclaration.Presentation.Controllers;
public class DeclarationController : Controller
{
    private readonly IHttpClientService _httpClientService;

    public DeclarationController(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _httpClientService
            .GetAsync<HttpResultBase<List<GetAllDeclarationsBriefDetailsQueryResponse>>>("api/v1/declarations/brief-details");

        return View(result.Payload);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeclaration(AddDeclarationCommand command)
    {

        return View();
    }

}
