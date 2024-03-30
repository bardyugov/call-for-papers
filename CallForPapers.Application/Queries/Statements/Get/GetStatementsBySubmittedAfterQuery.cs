using CallForPapers.Application.Commands.Statements.Create;
using MediatR;

namespace CallForPapers.Application.Queries.Statements.Get;

public class GetStatementsBySubmittedAfterQuery : IRequest<List<CreateStatementResult>>
{
    public DateTime Time { get; set; }

    public GetStatementsBySubmittedAfterQuery(DateTime time) => Time = time;
}