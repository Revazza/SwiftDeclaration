using MediatR;
using Microsoft.AspNetCore.Http;
using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Infrastructure.Models;

namespace SwiftDeclaration.Application.Declarations.Commands.UpdateDeclaration;

public record UpdateDeclarationCommand(
    int Id,
    string HeadLine = "",
    string Description = "",
    string PhoneNumber = "",
    IFormFile File = null!) : IRequest<HttpResult>;
