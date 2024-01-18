using Microsoft.AspNetCore.Http;
using SwiftDeclaration.Domain.ValueObjects.Images;

namespace SwiftDeclaration.Domain.Entities.Declarations;

/// <summary>
/// Represents a declaration entity containing information about a specific declaration
/// </summary>
public class Declaration
{
    /// <summary>
    /// Gets or sets the unique identifier for the declaration
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the headline of the declaration
    /// </summary>
    public string HeadLine { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the declaration
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the contact phone number associated with the declaration
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the image representation associated with the declaration
    /// </summary>
    public Image Image { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Declaration"/> class with default values
    /// </summary>
    public Declaration()
    {
        HeadLine = string.Empty;
        Description = string.Empty;
        PhoneNumber = string.Empty;
        Image = new Image(string.Empty, Array.Empty<byte>());
    }

    public void SetImage(IFormFile file)
    {
        Image = ImageHelper.ConvertFormFileToImage(file);
    }

}