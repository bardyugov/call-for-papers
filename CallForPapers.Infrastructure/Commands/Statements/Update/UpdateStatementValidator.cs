using CallForPapers.Application.Commands.Statements.Update;
using CallForPapers.Infrastructure.Literals;
using FluentValidation;

namespace CallForPapers.Infrastructure.Commands.Statements.Update;

public class UpdateStatementValidator : AbstractValidator<UpdateStatementCommand>
{
    public UpdateStatementValidator()
    {
        RuleFor(v => v.Name)
            .NotNull()
            .Length(3, 100);
        
        RuleFor(v => v.Description)
            .NotNull()
            .Length(3, 300);
        
        RuleFor(v => v.Outline)
            .NotNull()
            .Length(3, 1000);
        
        RuleFor(v => v.Activity)
            .Must(ActivityValidator)
            .WithMessage("Not valid activity");
    }
    
    private bool ActivityValidator(string value)
    {
        return Constants.ValidationActivities.Contains(value);
    }

}