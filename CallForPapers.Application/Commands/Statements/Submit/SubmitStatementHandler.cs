using CallForPapers.Contracts.Commands.Statements.Submit;
using CallForPapers.Contracts.Repositories;
using CallForPapers.Domain.Models;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Commands.Statements.Submit;

public class SubmitStatementHandler(IStatementRepository statementRepository)
    : IRequestHandler<SubmitStatementCommand, Result>
{
    public async Task<Result> Handle(SubmitStatementCommand request, CancellationToken cancellationToken)
    {
        var result = await statementRepository.FindById(request.Id, cancellationToken);
        if (result.IsFailed)
            return Result.Fail("Not found statement");

        var statement = result.Value;
        
        var confirmResult = statement.Confirm();
        if (confirmResult.IsFailed)
            return confirmResult;

        await statementRepository.Update(statement, cancellationToken);

        return Result.Ok();
    }
}