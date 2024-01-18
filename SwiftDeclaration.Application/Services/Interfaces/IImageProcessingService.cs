using Microsoft.AspNetCore.Http;
using SwiftDeclaration.Domain.ValueObjects.Images;

namespace SwiftDeclaration.Application.Services.Interfaces;

public interface IImageProcessingService
{
    Task<Image> ConvertFormFileToImageAsync(IFormFile file);
}
