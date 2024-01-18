using Mapster;
using MediatR;
using SwiftDeclaration.Application.Services.Interfaces;
using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;

public class AddDeclarationCommandHandler : IRequestHandler<AddDeclarationCommand, Declaration>
{
    private readonly IDeclarationRepository _declarationRepository;
    private readonly IImageProcessingService _imageProcessingService;
    private readonly IUnitOfWork _unitOfWork;

    public AddDeclarationCommandHandler(
        IDeclarationRepository declarationRepository,
        IImageProcessingService imageProcessingService,
        IUnitOfWork unitOfWork)
    {
        _declarationRepository = declarationRepository;
        _imageProcessingService = imageProcessingService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Declaration> Handle(AddDeclarationCommand request, CancellationToken cancellationToken)
    {
        var newDeclaration = request.Adapt<Declaration>();
        newDeclaration.Image = await _imageProcessingService.ConvertFormFileToImageAsync(request.File);

        await _declarationRepository.AddAsync(newDeclaration);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newDeclaration;
    }
}
