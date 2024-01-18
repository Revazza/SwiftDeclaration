using FluentValidation;
using SwiftDeclaration.Application.Declarations.Common;

namespace SwiftDeclaration.Application.Declarations.Commands.UpdateDeclaration;

public class UpdateDeclarationCommandValidator : AbstractValidator<UpdateDeclarationCommand>
{
    public UpdateDeclarationCommandValidator()
    {
        RuleFor(x => x)
            .Must(x => !IsAllPropertiesNullOrEmpty(x))
            .WithMessage("At least one of the properties (HeadLine, Description, PhoneNumber, or File) must be provided");
        RuleFor(x => x.Id).GreaterThan(2);

        RuleFor(x => x.HeadLine)
            .ValidateHeadLine()
            .When(x => !string.IsNullOrEmpty(x.HeadLine));

        RuleFor(x => x.Description)
            .ValidateDescription()
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.PhoneNumber)
            .ValidatePhoneNumber()
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

        RuleFor(x => x.File)
            .ValidateFile()
            .When(x => x is not null);

    }

    private static bool IsAllPropertiesNullOrEmpty(UpdateDeclarationCommand command)
    {
        return string.IsNullOrEmpty(command.HeadLine)
            && string.IsNullOrEmpty(command.Description)
            && string.IsNullOrEmpty(command.PhoneNumber)
            && command.File is null;
    }

}
