using CallForPapers.Application.Extensions;
using CallForPapers.Contracts.Queries.Statements.Get;
using FluentValidation;

namespace CallForPapers.Application.Queries.Statements.Get;

public class GetStatementByTimeValidator : AbstractValidator<GetStatementByTimeQuery>
{
    public GetStatementByTimeValidator()
    {
        RuleFor(x => x.SubmittedAfter)
            .Must((x, submittedAfter) => 
                submittedAfter.IsNotMin() && x.UnSubmittedOlder.IsMin() || submittedAfter.IsMin() && x.UnSubmittedOlder.IsNotMin())
            .WithMessage("Only one of SubmittedAfter or UnSubmittedOlder must be provided");

        RuleFor(x => x.UnSubmittedOlder)
            .Must((x, unSubmittedOlder) => 
                unSubmittedOlder.IsNotMin() && x.SubmittedAfter.IsMin() || unSubmittedOlder.IsMin() && x.SubmittedAfter.IsNotMin())
            .WithMessage("Only one of SubmittedAfter or UnSubmittedOlder must be provided");
    }
    
}