using CallForPapers.Application.Commands.Statements.Create;
using CallForPapers.Application.Repositories;
using CallForPapers.Domain.Models;
using FluentResults;
using MediatR;

namespace CallForPapers.Infrastructure.Commands.Statements.Create;

public class CreateStatementHandler : IRequestHandler<CreateStatementCommand, Result<CreateStatementResult>>
{
    private readonly IStatementRepository _statementRepository;
    private readonly IStatementActivityRepository _statementActivityRepository;

    public CreateStatementHandler(
        IStatementRepository statementRepository,
        IStatementActivityRepository statementActivityRepository
        )
    {
        _statementRepository = statementRepository;
        _statementActivityRepository = statementActivityRepository;
    }

    public async Task<Result<CreateStatementResult>> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
    {
        var statements = await _statementRepository.FindByAuthorId(request.Author, cancellationToken);
        var countUnconfirmedStatement = statements
            .Count(v => v.Status == Status.Unconfirmed);
        
        if (countUnconfirmedStatement == 1)
            return Result.Fail("You already have Unconfirmed statement");

        var activity = await _statementActivityRepository.FindByName(request.Activity, cancellationToken);
        if (activity.IsFailed)
            return Result.Fail(activity.Errors.Last().Message);

        Statement statement = new Statement
        {
            Id = Guid.NewGuid(),
            Author = request.Author,
            Name = request.Name,
            Description = request.Description,
            Outline = request.Outline,
            Activity = activity.Value,
            CreateDate = DateTime.Now.ToUniversalTime()
        };

        await _statementRepository.Create(statement, cancellationToken);
        await _statementRepository.SaveChanges(cancellationToken);

        var result = new CreateStatementResult(statement);

        return Result.Ok(result);
    }
}