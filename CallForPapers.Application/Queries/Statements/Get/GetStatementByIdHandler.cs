using CallForPapers.Contracts.Queries.Statements.Get;
using CallForPapers.Contracts.Repositories;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Queries.Statements.Get;

public class GetStatementByIdHandler(IStatementRepository statementRepository)
    : IRequestHandler<GetStatementByIdQuery, Result<GetStatementResultByQuery>>
{
    public async Task<Result<GetStatementResultByQuery>> Handle(GetStatementByIdQuery request, CancellationToken cancellationToken)
    {
        var statementResult = await statementRepository.FindById(request.Id, cancellationToken);
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