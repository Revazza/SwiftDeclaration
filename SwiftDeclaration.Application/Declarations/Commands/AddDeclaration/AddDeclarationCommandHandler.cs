using Mapster;
using MediatR;
using SwiftDeclaration.Application.Declarations.Dtos;
using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Infrastructure.Models;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;

public class AddDeclarationCommandHandler : IRequestHandler<AddDeclarationCommand, HttpResult>
{
    private readonly IDeclarationRepository _declarationRepository;
    private readonly ICachingService _cachingService;
    private readonly IUnitOfWork _unitOfWork;

    public AddDeclarationCommandHandler(
        IDeclarationRepository declarationRepository,
        IUnitOfWork unitOfWork,
        ICachingService cachingService)
    {
        _declarationRepository = declarationRepository;
        _unitOfWork = unitOfWork;
        _cachingService = cachingService;
    }

    public async Task<HttpResult> Handle(AddDeclarationCommand request, CancellationToken cancellationToken)
    {
        var newDeclaration = request.Adapt<Declaration>();
        newDeclaration.SetImage(request.File);

        await _declarationRepository.AddAsync(newDeclaration);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _cachingService.ClearCache();

        return HttpResult.Ok(newDeclaration.Adapt<DeclarationDto>());
    }
}
