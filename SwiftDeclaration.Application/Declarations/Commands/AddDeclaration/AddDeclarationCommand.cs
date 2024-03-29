﻿using MediatR;
using Microsoft.AspNetCore.Http;
using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Infrastructure.Models;

namespace SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;

public record AddDeclarationCommand(
    string Headline,
    string Description, 
    string PhoneNumber, 
    IFormFile File) : IRequest<HttpResult>;
