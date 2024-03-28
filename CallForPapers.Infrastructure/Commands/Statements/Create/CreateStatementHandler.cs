using CallForPapers.Application.Commands.Statements.Create;
using CallForPapers.Application.Repositories;
using CallForPapers.Domain.Models;
using FluentResults;
using MediatR;

namespace CallForPapers.Infrastructure.Commands.Statements.Create;

public class CreateStatementHandler : IRequestHandler<CreateStatementCommand, Result<CreateStatementResult>>
{
    private readonly IStatementRepository _repository;

    public CreateStatementHandler(IStatementRepository repository) => _repository = repository;

    private TypeActivity MapTypeActivity(string value) =>
        value switch
        {
            "Report" => TypeActivity.Report,
            "Masterclass" => TypeActivity.Masterclass,
            "Discussion" => TypeActivity.Discussion,
            _ => TypeActivity.Report
        };
    
    public async Task<Result<CreateStatementResult>> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
    {
        var statements = await _repository.FindByAuthorId(request.Author, cancellationToken);
        var countUnconfirmedStatement = statements
            .Count(v => v.Status == Status.Unconfirmed);
        
        if (countUnconfirmedStatement == 1)
            return Result.Fail("You already have Unconfirmed statement");

        Statement statement = new Statement
        {
            Id = Guid.NewGuid(),
            Author = request.Author,
            Name = request.Name,
            Description = request.Description,
            Outline = request.Outline,
            Activity = MapTypeActivity(request.Type)
        };

        await _repository.Create(statement, cancellationToken);
        await _repository.SaveChanges(cancellationToken);

        var result = CreateStatementResult.Create(statement);

        return Result.Ok(result);
    }
}