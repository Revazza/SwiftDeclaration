namespace SwiftDeclaration.Domain.ValueObjects.Images;

public class ImageErrorMessages
{
    // Using readonly due to expression in the message
    public static readonly string ImageSizeExceeded = $"The file must not exceed {ImageOptions.MaxFileSize} mb";
}
