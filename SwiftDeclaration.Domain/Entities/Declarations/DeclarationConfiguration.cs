namespace SwiftDeclaration.Domain.Entities.Declarations;

public class DeclarationConfiguration
{
    public const int MaxHeadLineLength = 128;
    public const int MaxDescriptionLength = 256;
    public const string PhoneNumberRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
}
