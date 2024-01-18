using FluentValidation;
using MediatR;
using SwiftDeclaration.Infrastructure.Models;

namespace SwiftDeclaration.Infrastructure.Behaviours;

public class FluentValidationBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>

{
    private readonly IValidator<TRequest>? _validator;

    public FluentValidationBehaviour(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return (dynamic)HttpResult.NotOk(validationResult.Errors.First().ErrorMessage);
        }

        return await next();
    }

}


