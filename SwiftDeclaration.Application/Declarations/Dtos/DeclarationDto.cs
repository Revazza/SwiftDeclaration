namespace SwiftDeclaration.Application.Declarations.Dtos;

public record DeclarationDto(
    int Id,
    string Headline,
    string Description,
    string PhoneNumber,
    string ImageBase64);
