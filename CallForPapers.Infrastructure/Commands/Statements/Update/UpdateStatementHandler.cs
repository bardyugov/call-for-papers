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
        
        var statement = resultStatement.Value;
        
        if (request.Activity != null)
        {
            var findingActivity = await _statementActivityRepository.FindByName(request.Activity, cancellationToken);
            if (findingActivity.IsFailed)
                return Result.Fail("Not found activity");
            statement.Activity = findingActivity.Value;
        }

        statement.Outline = request.Outline ?? statement.Outline;
        statement.Description = request.Description ?? statement.Description;
        statement.Name = request.Name ?? statement.Name;
        
        await _statementRepository.Update(statement, cancellationToken);
        await _statementRepository.SaveChanges(cancellationToken);
        
        var result = new CreateStatementResult(statement);

        return Result.Ok(result);
    }
}