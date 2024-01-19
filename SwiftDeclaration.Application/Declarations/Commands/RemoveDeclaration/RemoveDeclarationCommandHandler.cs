using MediatR;
using SwiftDeclaration.Application.Declarations.Queries.GetDeclarationById;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Application.Declarations.Commands.RemoveDeclaration;

public record RemoveDeclarationCommand(int DeclarationId) : IRequest;

public class RemoveDeclarationCommandHandler : IRequestHandler<RemoveDeclarationCommand>
{
    private readonly IDeclarationRepository _declarationRepository;
    private readonly ISender _mediator;
    private readonly ICachingService _cachingService;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveDeclarationCommandHandler(
        IUnitOfWork unitOfWork,
        IDeclarationRepository declarationRepository,
        ISender mediator,
        ICachingService cachingService)
    {
        _unitOfWork = unitOfWork;
        _declarationRepository = declarationRepository;
        _mediator = mediator;
        _cachingService = cachingService;
    }

    public async Task Handle(RemoveDeclarationCommand request, CancellationToken cancellationToken)
    {
        var declaration = await _mediator
            .Send(new GetDeclarationByIdQuery(request.DeclarationId), cancellationToken)
            ?? throw new Exception();

        _declarationRepository.Remove(declaration);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _cachingService.ClearCache();
    }
}
