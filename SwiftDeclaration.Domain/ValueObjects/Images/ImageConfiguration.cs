using SwiftDeclaration.Domain.Enums;

namespace SwiftDeclaration.Domain.ValueObjects.Images;

public class ImageConfiguration
{
    public const int MaxFileNameLength = 256;
    public const FileSize MaxFileSize = FileSize.TenMegaBytes;
}
