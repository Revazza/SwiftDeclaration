using FluentValidation;
using SwiftDeclaration.Application.Declarations.Common;

namespace SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;

public class AddDeclarationCommandValidator : AbstractValidator<AddDeclarationCommand>
{

    public AddDeclarationCommandValidator()
    {
        RuleFor(x => x.HeadLine)
            .ValidateHeadLine();

        RuleFor(x => x.Description)
            .ValidateDescription();

        RuleFor(x => x.PhoneNumber)
            .ValidatePhoneNumber();

        RuleFor(x => x.File)
            .ValidateFile();
    }

}
