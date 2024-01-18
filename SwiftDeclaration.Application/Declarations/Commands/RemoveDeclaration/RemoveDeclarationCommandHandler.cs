using MediatR;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Commands.RemoveDeclaration;

public record RemoveDeclarationCommand(int DeclarationId) : IRequest;

public class RemoveDeclarationCommandHandler : IRequestHandler<RemoveDeclarationCommand>
{
    private readonly IDeclarationRepository _declarationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveDeclarationCommandHandler(
        IUnitOfWork unitOfWork,
        IDeclarationRepository declarationRepository)
    {
        _unitOfWork = unitOfWork;
        _declarationRepository = declarationRepository;
    }

    public async Task Handle(RemoveDeclarationCommand request, CancellationToken cancellationToken)
    {
        var declaration = await _declarationRepository.GetByIdAsync(request.DeclarationId)
            ?? throw new Exception("");

        _declarationRepository.Remove(declaration);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
