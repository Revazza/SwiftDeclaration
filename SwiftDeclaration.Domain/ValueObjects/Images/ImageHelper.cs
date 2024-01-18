using Microsoft.AspNetCore.Http;

namespace SwiftDeclaration.Domain.ValueObjects.Images;

public class ImageHelper
{
    public static Image ConvertFormFileToImage(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        var imageData = memoryStream.ToArray();

        return new Image(file.FileName, imageData);
    }
}
