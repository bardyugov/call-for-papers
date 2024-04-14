using CallForPapers.Application.Commands.Statements.Create;
using MediatR;

namespace CallForPapers.Application.Queries.Statements.Get;

public class GetStatementsByUnSubmittedOlderQuery : IRequest<List<CreateStatementResult>>
{
    public DateTime Time { get; set; }

    public GetStatementsByUnSubmittedOlderQuery(DateTime time) => Time = time;
}