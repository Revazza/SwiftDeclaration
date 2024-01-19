using FluentValidation;
using Microsoft.AspNetCore.Http;
using SwiftDeclaration.Domain.Entities.Declarations;
using SwiftDeclaration.Domain.ValueObjects.Images;

namespace SwiftDeclaration.Application.Declarations.Common;

/// <summary>
/// Provides fluent validation rules for the properties of the Declaration entity
/// </summary>
public static class DeclarationValidationRules
{
    public static IRuleBuilderOptions<T, string?> ValidateHeadLine<T>(this IRuleBuilder<T, string?> ruleBuilder)
        => ruleBuilder
        .MaximumLength(DeclarationOptions.MaxHeadLineLength);

    public static IRuleBuilderOptions<T, string?> ValidateDescription<T>(this IRuleBuilder<T, string?> ruleBuilder)
        => ruleBuilder
        .MaximumLength(DeclarationOptions.MaxDescriptionLength);

    public static IRuleBuilderOptions<T, string?> ValidatePhoneNumber<T>(this IRuleBuilder<T, string?> ruleBuilder)
        => ruleBuilder
        .Matches(DeclarationOptions.PhoneNumberRegex)
        .WithMessage(DeclarationErrorMessages.InvalidPhoneNumberFormat)
        .MaximumLength(DeclarationOptions.MaxPhoneNumberLength);

    public static IRuleBuilderOptions<T, IFormFile?> ValidateFile<T>(this IRuleBuilder<T, IFormFile?> ruleBuilder)
       => ruleBuilder
        .Must(file => file?.Length <= (int)ImageOptions.MaxFileSize)
        .WithMessage(ImageErrorMessages.ImageSizeExceeded);

}
