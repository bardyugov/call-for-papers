using MediatR;

namespace CallForPapers.Application.Queries.StatementActivities.Get;

public class GetStatementActivitiesQuery : IRequest<List<GetStatementActivitiesResult>>
{
}