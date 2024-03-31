using CallForPapers.Application.Commands.Statements.Update;
using FluentValidation;
using MediatR;

namespace CallForPapers.Core.Behavior;

public class ValidationBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
    
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .ToList();

        if (request is UpdateStatementCommand && failures.Count == 4)
        {
            throw new ValidationException(failures);
        }
        
        if (failures.Count != 0 && request is not UpdateStatementCommand)
        {
            throw new ValidationException(failures);
        }

        return next();
    }
}