using Azure.Core;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using SwiftDeclaration.Application.Declarations.Dtos;
using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Infrastructure.Models;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Commands.UpdateDeclaration;

public class UpdateDeclarationCommandHandler : IRequestHandler<UpdateDeclarationCommand, HttpResult>
{
    private readonly IDeclarationRepository _declarationRepository;
    private readonly ICachingService _cachingService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDeclarationCommandHandler(
        IUnitOfWork unitOfWork,
        IDeclarationRepository declarationRepository,
        ICachingService cachingService)
    {
        _unitOfWork = unitOfWork;
        _declarationRepository = declarationRepository;
        _cachingService = cachingService;
    }

    public async Task<HttpResult> Handle(UpdateDeclarationCommand request, CancellationToken cancellationToken)
    {
        var declaration = await _declarationRepository.GetByIdAsync(request.Id)
            ?? throw new ArgumentException();

        UpdateProperties(declaration, request);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _cachingService.ClearCache();
        return HttpResult.Ok(declaration.Adapt<DeclarationDto>());
    }

    private static void UpdateProperties(Declaration declaration, UpdateDeclarationCommand request)
    {
        UpdateHeadLineIfNotEmpty(declaration, request.HeadLine);
        UpdateDescriptionIfNotEmpty(declaration, request.Description);
        UpdatePhoneNumberIfNotEmpty(declaration, request.PhoneNumber);
        UpdateImageIfNotNull(declaration, request.File);
    }

    private static void UpdateHeadLineIfNotEmpty(Declaration declaration, string headLine)
        => declaration.Headline = string.IsNullOrEmpty(headLine) ? declaration.Headline : headLine;

    private static void UpdateDescriptionIfNotEmpty(Declaration declaration, string description)
        => declaration.Description = string.IsNullOrEmpty(description) ? declaration.Description : description;

    private static void UpdatePhoneNumberIfNotEmpty(Declaration declaration, string phoneNumber)
       => declaration.PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? declaration.PhoneNumber : phoneNumber;

    private static void UpdateImageIfNotNull(Declaration declaration, IFormFile file)
    {
        if (file is null)
        {
            return;
        }
        declaration.SetImage(file);
    }

}
