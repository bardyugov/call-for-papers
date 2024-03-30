using CallForPapers.Application.Commands.Statements.Create;
using CallForPapers.Application.Commands.Statements.Update;
using CallForPapers.Application.Repositories;
using CallForPapers.Domain.Models;
using FluentResults;
using MediatR;

namespace CallForPapers.Infrastructure.Commands.Statements.Update;

public class UpdateStatementHandler : IRequestHandler<UpdateStatementCommand, Result<CreateStatementResult>>
{
    private readonly IStatementRepository _statementRepository;
    private readonly IStatementActivityRepository _statementActivityRepository;

    public UpdateStatementHandler(
        IStatementRepository statementRepository, 
        IStatementActivityRepository statementActivityRepository
        )
    {
        _statementRepository = statementRepository;
        _statementActivityRepository = statementActivityRepository;
    }

    public async Task<Result<CreateStatementResult>> Handle(UpdateStatementCommand request, CancellationToken cancellationToken)
    {
        var resultStatement = await _statementRepository.FindById(request.Id, cancellationToken);
        if (resultStatement.IsFailed)
            return Result.Fail("Not found statement");

        if (resultStatement.Value.Status == Status.Confirmed)
            return Result.Fail("You can't change confirmed statement");

        var activity = await _statementActivityRepository.FindByName(request.Data.Activity, cancellationToken);
        if (activity.IsFailed)
            return Result.Fail("Not found activity");

        var statement = resultStatement.Value;
        
        statement.Outline = request.Data.Outline;
        statement.Description = request.Data.Description;
        statement.Name = request.Data.Name;
        statement.Activity = activity.Value;
        
        await _statementRepository.Update(statement, cancellationToken);
        await _statementRepository.SaveChanges(cancellationToken);
        
        var result = new CreateStatementResult(statement);

        return Result.Ok(result);
    }
}