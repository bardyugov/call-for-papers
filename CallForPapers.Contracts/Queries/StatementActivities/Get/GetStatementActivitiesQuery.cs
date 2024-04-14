using FluentResults;
using MediatR;

namespace CallForPapers.Contracts.Queries.StatementActivities.Get;

public class GetStatementActivitiesQuery : IRequest<Result<List<GetStatementActivitiesResult>>>
{
}