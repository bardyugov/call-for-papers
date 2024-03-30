using CallForPapers.Application.Commands.Statements.Create;
using CallForPapers.Application.Queries.Statements.Get;
using CallForPapers.Application.Repositories;
using CallForPapers.Domain.Models;
using MediatR;

namespace CallForPapers.Infrastructure.Queries.Statements.Get;

public class GetStatementsBySubmittedAfterHandler 
    : IRequestHandler<GetStatementsBySubmittedAfterQuery, List<CreateStatementResult>>
{
    private readonly IStatementRepository _statementRepository;

    public GetStatementsBySubmittedAfterHandler(IStatementRepository repository) => _statementRepository = repository;
    
    public async Task<List<CreateStatementResult>> Handle(GetStatementsBySubmittedAfterQuery request, CancellationToken cancellationToken)
    {
        var statements = await _statementRepository.FindByAfterDate(request.Time, cancellationToken);
        var result = statements
            .Where(v => v.Status == Status.Confirmed)
            .Select(v => new CreateStatementResult(v))
            .ToList();

        return result;
    }
}