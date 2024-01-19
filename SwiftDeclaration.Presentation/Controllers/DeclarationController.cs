using Microsoft.AspNetCore.Mvc;
using SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;
using SwiftDeclaration.Application.Declarations.Commands.UpdateDeclaration;
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

    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDeclaration(UpdateDeclarationCommand command)
    {
        await _httpClientService.PostMultipartFormDataAsync("api/v1/declarations/update", command);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeclaration(AddDeclarationCommand command)
    {
        await _httpClientService.PostMultipartFormDataAsync("api/v1/declarations", command);
        return RedirectToAction("Index");
    }

}
