namespace SwiftDeclaration.Application.Declarations.Dtos;

public record DeclarationDto(
    int Id,
    string HeadLine,
    string Description,
    string PhoneNumber,
    string ImageBase64);
