using CallForPapers.Contracts.Commands.Statements.Remove;
using CallForPapers.Contracts.Repositories;
using CallForPapers.Domain.Models;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Commands.Statements.Remove;

public class RemoveStatementHandler(IStatementRepository repository)
    : IRequestHandler<RemoveStatementCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RemoveStatementCommand request, CancellationToken cancellationToken)
    {
        var isFind = await repository.FindById(request.Id, cancellationToken);
        if (isFind.IsFailed)
            return Result.Fail(isFind.Errors.Last().Message);

        if (isFind.Value.Status == Status.Confirmed)
            return Result.Fail("You can't remove statement");
        
        await repository.Remove(isFind.Value.Id, cancellationToken);

        return Result.Ok("Statement success remove");
    }
}