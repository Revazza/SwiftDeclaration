using MediatR;
using Microsoft.AspNetCore.Http;
using SwiftDeclaration.Domain.Entities.Declarations;

namespace SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;

public record AddDeclarationCommand(
    string HeadLine,
    string Description, 
    string PhoneNumber, 
    IFormFile File) : IRequest<Declaration>;
