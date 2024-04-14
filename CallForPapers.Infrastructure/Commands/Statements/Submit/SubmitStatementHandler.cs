using CallForPapers.Application.Commands.Statements.Submit;
using CallForPapers.Application.Repositories;
using CallForPapers.Domain.Models;
using FluentResults;
using MediatR;

namespace CallForPapers.Infrastructure.Commands.Statements.Submit;

public class SubmitStatementHandler : IRequestHandler<SubmitStatementCommand, Result>
{
    private readonly IStatementRepository _statementRepository;

    public SubmitStatementHandler(IStatementRepository statementRepository) =>
        _statementRepository = statementRepository;
    
    public async Task<Result> Handle(SubmitStatementCommand request, CancellationToken cancellationToken)
    {
        var result = await _statementRepository.FindById(request.Id, cancellationToken);
        if (result.IsFailed)
            return Result.Fail("Not found statement");

        var statement = result.Value;
        if (statement.Status == Status.Confirmed)
            return Result.Fail("Statement already confirmed");

        statement.Status = Status.Confirmed;
        statement.SubmittedTime = DateTime.Now.ToUniversalTime();

        await _statementRepository.Update(statement, cancellationToken);
        await _statementRepository.SaveChanges(cancellationToken);

        return Result.Ok();
    }
}