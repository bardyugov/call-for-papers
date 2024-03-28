using CallForPapers.Application.Commands.Statements.Create;
using FluentValidation;

namespace CallForPapers.Infrastructure.Commands.Statements.Create;

public class CreateStatementValidator : AbstractValidator<CreateStatementCommand>
{
    public CreateStatementValidator()
    {
        RuleFor(v => v.Name)
            .Length(3, 100);

        RuleFor(v => v.Description)
            .Must(DescriptionValidator)
            .WithMessage("Not valid description");

        RuleFor(v => v.Outline)
            .Length(3, 1000);

        RuleFor(v => v.Author)
            .NotEmpty();

        RuleFor(v => v.Type)
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