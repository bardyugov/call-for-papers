using CallForPapers.Application.Commands.Statements.Create;
using CallForPapers.Infrastructure.Literals;
using FluentValidation;

namespace CallForPapers.Infrastructure.Commands.Statements.Create;

public class CreateStatementValidator : AbstractValidator<CreateStatementCommand>
{
    public CreateStatementValidator()
    {
        RuleFor(v => v.Name)
            .NotNull()
            .Length(3, 100);

        RuleFor(v => v.Description)
            .Must(DescriptionValidator)
            .WithMessage("Not valid description");

        RuleFor(v => v.Outline)
            .NotNull()
            .Length(3, 1000);

        RuleFor(v => v.Author)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(v => v.Activity)
            .Must(ActivityValidator)
            .WithMessage("Not valid activity");
    }

    private bool ActivityValidator(string value)
    {
        return Constants.ValidationActivities.Contains(value);
    }

    private bool DescriptionValidator(string value)
    {
        if (value is null)
            return true;

        return value.Length > 2 && value.Length < 301;
    }
}