using CallForPapers.Contracts.Queries.Statements.Get;
using CallForPapers.Contracts.Repositories;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Queries.Statements.Get;

public class GetStatementByAuthorIdHandler(IStatementRepository statementRepository)
    : IRequestHandler<GetStatementByAuthorIdQuery, Result<GetStatementResultByQuery>>
{
    public async Task<Result<GetStatementResultByQuery>> Handle(GetStatementByAuthorIdQuery request, CancellationToken cancellationToken)
    {
        var statementResult = await statementRepository.FindByAuthorIdUnconfirmed(request.AuthorId, cancellationToken);
        if (statementResult.IsFailed)
            return Result.Fail("Not found statement");

        var statement = statementResult.Value;
        var result = new GetStatementResultByQuery
        {
            Id = statement.Id,
            Author = statement.Author,
            Name = statement.Name,
            Description = statement.Description,
            Outline = statement.Outline,
            Activity = statement.Activity.Name
        };

        return Result.Ok(result);
    }
}