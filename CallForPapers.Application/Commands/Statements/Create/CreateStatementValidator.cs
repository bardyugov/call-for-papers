using CallForPapers.Contracts.Commands.Statements.Create;
using FluentValidation;

namespace CallForPapers.Application.Commands.Statements.Create;

public class CreateStatementValidator : AbstractValidator<CreateStatementCommand>
{
    public CreateStatementValidator()
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

        RuleFor(v => v.Author)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(v => v.Activity)
            .NotNull()
            .Length(3, 30)
            .WithMessage("Not valid activity");
    }
    
}