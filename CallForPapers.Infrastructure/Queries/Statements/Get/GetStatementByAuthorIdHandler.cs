using CallForPapers.Application.Commands.Statements.Create;
using CallForPapers.Application.Queries.Statements.Get;
using CallForPapers.Application.Repositories;
using FluentResults;
using MediatR;

namespace CallForPapers.Infrastructure.Queries.Statements.Get;

public class GetStatementByAuthorIdHandler : IRequestHandler<GetStatementByAuthorIdQuery, Result<CreateStatementResult>>
{
    private readonly IStatementRepository _statementRepository;

    public GetStatementByAuthorIdHandler(IStatementRepository statementRepository) => _statementRepository = statementRepository;

    public async Task<Result<CreateStatementResult>> Handle(GetStatementByAuthorIdQuery request, CancellationToken cancellationToken)
    {
        var statementResult = await _statementRepository.FindByAuthorIdUnconfirmedStatement(request.AuthorId, cancellationToken);
        if (statementResult.IsFailed)
            return Result.Fail("Not found statement");

        var result = new CreateStatementResult(statementResult.Value);

        return Result.Ok(result);
    }
}