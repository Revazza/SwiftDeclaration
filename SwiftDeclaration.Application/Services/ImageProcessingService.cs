using Microsoft.AspNetCore.Http;
using SwiftDeclaration.Application.Services.Interfaces;
using SwiftDeclaration.Domain.ValueObjects.Images;

namespace SwiftDeclaration.Application.Services;

public class ImageProcessingService : IImageProcessingService
{
    public async Task<Image> ConvertFormFileToImageAsync(IFormFile file)
    {
        var fileName = file.FileName;

        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        var imageData = memoryStream.ToArray();

        return new Image(fileName, imageData);
    }
}
