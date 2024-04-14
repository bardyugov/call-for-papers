using CallForPapers.Contracts.Commands.Statements.Update;
using FluentValidation;

namespace CallForPapers.Application.Commands.Statements.Update;

public class UpdateStatementValidator : AbstractValidator<UpdateStatementCommand>
{
    public UpdateStatementValidator()
    {
        RuleFor(x => x.Author)
            .NotNull()
            .NotEqual(Guid.Empty)
            .WithMessage("Author is required");
        
        RuleFor(x => x.Name)
            .NotNull()
            .Length(3, 100)
            .When(x => 
                IsNull(x.Description) && IsNull(x.Outline) && IsNull(x.Activity) 
                || IsNotNull(x.Name))
            .WithMessage("At least one of the fields (Activity, Name, Description, Outline) is required.");
        
        RuleFor(x => x.Description)
            .NotNull()
            .Length(3, 300)
            .When(x => 
                IsNull(x.Name) && IsNull(x.Outline) && IsNull(x.Activity) 
                || IsNotNull(x.Description))
            .WithMessage("At least one of the fields (Activity, Name, Description, Outline) is required.");
        
        RuleFor(x => x.Outline)
            .NotNull()
            .Length(3, 100)
            .When(x => 
                IsNull(x.Name) && IsNull(x.Description) && IsNull(x.Activity) 
                || IsNotNull(x.Outline))
            .WithMessage("At least one of the fields (Activity, Name, Description, Outline) is required.");

    
        RuleFor(x => x.Activity)
            .NotNull()
            .Length(3, 30)
            .When(x => 
                IsNull(x.Name) && IsNull(x.Description) && IsNull(x.Outline) 
                || IsNotNull(x.Activity))
            .WithMessage("At least one of the fields (Activity, Name, Description, Outline) is required.");
    }

    private bool IsNull(string? value) => value is null;

    private bool IsNotNull(string value) => !IsNull(value);
    
}