using CallForPapers.Application.Commands.Statements.Create;
using CallForPapers.Application.Queries.Statements.Get;
using CallForPapers.Application.Repositories;
using CallForPapers.Domain.Models;
using MediatR;

namespace CallForPapers.Infrastructure.Queries.Statements.Get;

public class GetStatementsByUnSubmittedOlderHandler 
    : IRequestHandler<GetStatementsByUnSubmittedOlderQuery, List<CreateStatementResult>>
{
    private readonly IStatementRepository _statementRepository;

    public GetStatementsByUnSubmittedOlderHandler(IStatementRepository repository) => _statementRepository = repository;
    
    public async Task<List<CreateStatementResult>> Handle(GetStatementsByUnSubmittedOlderQuery request, CancellationToken cancellationToken)
    {
        var statements = await _statementRepository.FindByByOlderDate(request.Time, cancellationToken);
        var result = statements
            .Where(v => v.Status == Status.Unconfirmed)
            .Select(v => new CreateStatementResult(v))
            .ToList();

        return result;
    }
}