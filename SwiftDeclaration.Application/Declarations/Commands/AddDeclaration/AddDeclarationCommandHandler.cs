using MediatR;
using SwiftDeclaration.Persistance.Repositories.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;

public class AddDeclarationCommandHandler : IRequestHandler<AddDeclarationCommand>
{
    private readonly IDeclarationRepository _declarationRepository;

    public AddDeclarationCommandHandler(IDeclarationRepository declarationRepository)
    {
        _declarationRepository = declarationRepository;
    }

    public async Task Handle(AddDeclarationCommand request, CancellationToken cancellationToken)
    {
        
    }
}
