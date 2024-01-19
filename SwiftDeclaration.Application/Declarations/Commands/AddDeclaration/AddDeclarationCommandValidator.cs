using FluentValidation;
using SwiftDeclaration.Application.Declarations.Common;

namespace SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;

public class AddDeclarationCommandValidator : AbstractValidator<AddDeclarationCommand>
{

    public AddDeclarationCommandValidator()
    {
        RuleFor(x => x.Headline)
            .NotEmpty()
            .ValidateHeadLine();

        RuleFor(x => x.Description)
            .NotEmpty()
            .ValidateDescription();

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .ValidatePhoneNumber();

        RuleFor(x => x.File)
            .NotNull()
            .ValidateFile();
    }

}
