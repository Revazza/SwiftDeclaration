using Microsoft.AspNetCore.Mvc;
using SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;
using SwiftDeclaration.Application.Declarations.Commands.UpdateDeclaration;
using SwiftDeclaration.Application.Declarations.Dtos;
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
    public async Task<IActionResult> Index(string headline)
    {
        var result = await _httpClientService
            .GetAsync<HttpResultBase<List<GetAllDeclarationsBriefDetailsQueryResponse>>>($"api/v1/declarations/brief-details?headline={headline}");

        return View(result.Payload);
    }

    [HttpGet]


    [HttpGet]
    public async Task<IActionResult> SearchDeclaration(string headline)
    {
        var result = await _httpClientService
            .GetAsync<HttpResultBase<List<GetAllDeclarationsBriefDetailsQueryResponse>>>($"api/v1/declarations/brief-details?headline={headline}");

        return View("Index", result);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        ViewData["Id"] = id;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _httpClientService.DeleteAsync($"api/v1/declarations/{id}");
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var result = await _httpClientService.GetAsync<HttpResultBase<DeclarationDto>>($"api/v1/declarations/{id}");
        return View(result.Payload);
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
