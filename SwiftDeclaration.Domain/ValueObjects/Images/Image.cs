namespace SwiftDeclaration.Domain.ValueObjects.Images;

/// <summary>
/// Represents an image with a file name and binary data
/// </summary>
public record Image
{
    /// <summary>
    /// Gets the file name associated with the image
    /// </summary>
    public string FileName { get; init; }

    /// <summary>
    /// Gets the binary data representing the image
    /// </summary>
    public byte[] Data { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Image"/> record with the specified file name and binary data
    /// </summary>
    /// <param name="FileName">The name of the image file</param>
    /// <param name="Data">The binary data representing the image</param>
    public Image(string FileName, byte[] Data)
    {
        this.FileName = FileName;
        this.Data = Data;
    }

    /// <summary>
    /// Get the Base64 string representation of the image data
    /// </summary>
    public string GetBase64String()
    {
        if (!Data.Any())
        {
            return string.Empty;
        }

        return $"data:{FileName};base64,{Convert.ToBase64String(Data)}";
    }
}
