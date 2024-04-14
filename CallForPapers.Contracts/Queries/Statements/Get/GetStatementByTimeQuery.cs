using FluentResults;
using MediatR;

namespace CallForPapers.Contracts.Queries.Statements.Get;

public class GetStatementByTimeQuery : IRequest<Result<List<GetStatementResultByQuery>>>
{
    public DateTime SubmittedAfter { get; set; }

    public DateTime UnSubmittedOlder { get; set; }
}