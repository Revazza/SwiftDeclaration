using MediatR;
using SwiftDeclaration.Domain.Entities.Declarations;

namespace SwiftDeclaration.Application.Declarations.Queries.GetDeclarationById;

public record GetDeclarationByIdQuery(int DeclarationId) : IRequest<Declaration?>;
