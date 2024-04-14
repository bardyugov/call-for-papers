using CallForPapers.Contracts.Commands.Statements.Create;
using CallForPapers.Contracts.Repositories;
using CallForPapers.Domain.Models;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Commands.Statements.Create;

public class CreateStatementHandler(
    IStatementRepository statementRepository,
    IStatementActivityRepository statementActivityRepository)
    : IRequestHandler<CreateStatementCommand, Result<CreateStatementResult>>
{
    public async Task<Result<CreateStatementResult>> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
    {
        var statements = await statementRepository.FindByAuthorId(request.Author, cancellationToken);
        var countUnconfirmedStatement = statements
            .Count(v => v.Status == Status.Unconfirmed);
        
        if (countUnconfirmedStatement == 1)
            return Result.Fail("You already have Unconfirmed statement");

        var activity = await statementActivityRepository.FindByName(request.Activity, cancellationToken);
        if (activity.IsFailed)
            return Result.Fail(activity.Errors.Last().Message);

        var statement = new Statement(
            Guid.NewGuid(),
            request.Author,
            activity.Value,
            request.Name,
            request.Description,
            request.Outline,
            DateTime.Now.ToUniversalTime(),
            null,
            Status.Unconfirmed
        );

        await statementRepository.Create(statement, cancellationToken);

        var result = new CreateStatementResult
        {
            Id = statement.Id,
            Author = request.Author,
            Activity = request.Activity,
            Name = request.Name,
            Description = request.Description,
            Outline = request.Outline,
        };

        return Result.Ok(result);
    }
}