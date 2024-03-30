using CallForPapers.Application.Commands.Statements.Update;
using FluentValidation;

namespace CallForPapers.Infrastructure.Commands.Statements.Update;

public class UpdateStatementValidator : AbstractValidator<UpdateStatementData>
{
    public UpdateStatementValidator()
    {
        RuleFor(v => v.Name)
            .Length(3, 100);

        RuleFor(v => v.Description)
            .Must(DescriptionValidator)
            .WithMessage("Not valid description");

        RuleFor(v => v.Outline)
            .Length(3, 1000);

        RuleFor(v => v.Activity)
            .Must(ActivityValidator)
            .WithMessage("Not valid activity");
    }
    
    private bool ActivityValidator(string value)
    {
        List<string> values = ["Report", "Masterclass", "Discussion"];
        return values.Contains(value);
    }

    private bool DescriptionValidator(string value)
    {
        if (value is null)
            return true;

        return value.Length > 2 && value.Length < 301;
    }
}