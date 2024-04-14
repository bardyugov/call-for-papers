using CallForPapers.Contracts.Queries.StatementActivities.Get;
using CallForPapers.Contracts.Repositories;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Queries.StatementActivities;

public class GetStatementActivitiesHandler(IStatementActivityRepository repository)
    : IRequestHandler<GetStatementActivitiesQuery, Result<List<GetStatementActivitiesResult>>>
{
    public async Task<Result<List<GetStatementActivitiesResult>>> Handle(GetStatementActivitiesQuery request, CancellationToken cancellationToken)
    {
        var activities = await repository.Find(cancellationToken);
        var result = activities
            .Select(v => new GetStatementActivitiesResult { Activity = v.Name, Description = v.Description })
            .ToList();
        
        return Result.Ok(result);
    }
}