using CallForPapers.Contracts.Commands.Statements.Update;
using CallForPapers.Contracts.Repositories;
using CallForPapers.Domain.Models;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Commands.Statements.Update;

public class UpdateStatementHandler(
    IStatementRepository statementRepository,
    IStatementActivityRepository statementActivityRepository)
    : IRequestHandler<UpdateStatementCommand, Result<UpdateStatementResult>>
{
    public async Task<Result<UpdateStatementResult>> Handle(UpdateStatementCommand request, CancellationToken cancellationToken)
    {
        var statementResult = await statementRepository.FindById(request.Id, cancellationToken);
        if (statementResult.IsFailed)
            return Result.Fail(statementResult.Errors.Last().Message);

        var statement = statementResult.Value;
        if (statement.Status == Status.Confirmed)
            return Result.Fail("You can't change confirmed statement");
        
        if (request.Activity != null)
        {
            var activityResult = await statementActivityRepository.FindByName(request.Activity, cancellationToken);
            if (activityResult.IsFailed)
                return Result.Fail(activityResult.Errors.Last().Message);
            statement.SetActivity(activityResult.Value);
        }

        statement.SetInfo(request.Name, request.Description, request.Outline);
        await statementRepository.Update(statement, cancellationToken);

        var result = new UpdateStatementResult
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