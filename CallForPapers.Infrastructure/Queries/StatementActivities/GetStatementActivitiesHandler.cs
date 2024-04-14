using CallForPapers.Application.Queries.StatementActivities.Get;
using CallForPapers.Application.Repositories;
using MediatR;

namespace CallForPapers.Infrastructure.Queries.StatementActivities;

public class GetStatementActivitiesHandler : IRequestHandler<GetStatementActivitiesQuery, List<GetStatementActivitiesResult>>
{
    private readonly IStatementActivityRepository _statementActivityRepository;

    public GetStatementActivitiesHandler(IStatementActivityRepository repository) => _statementActivityRepository = repository;

    public async Task<List<GetStatementActivitiesResult>> Handle(GetStatementActivitiesQuery request, CancellationToken cancellationToken)
    {
        var activities = await _statementActivityRepository.Find(cancellationToken);
        var result = activities
            .Select(v => new GetStatementActivitiesResult(v))
            .ToList();
        
        return result;
    }
}