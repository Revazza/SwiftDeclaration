using MediatR;
using Microsoft.AspNetCore.Http;

namespace SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;


public record AddDeclarationCommand(
    string HeadLine,
    string Description, 
    string PhoneNumber, 
    IFormFile File) : IRequest;
