using CallForPapers.Application.Commands.Statements.Remove;
using CallForPapers.Application.Repositories;
using FluentResults;
using MediatR;

namespace CallForPapers.Infrastructure.Commands.Statements.Remove;

public class RemoveStatementHandler : IRequestHandler<RemoveStatementCommand, Result<string>>
{
    private readonly IStatementRepository _statementRepository;

    public RemoveStatementHandler(IStatementRepository repository) => _statementRepository = repository;
    
    public async Task<Result<string>> Handle(RemoveStatementCommand request, CancellationToken cancellationToken)
    {
        var isFind = await _statementRepository.FindById(request.Id, cancellationToken);
        if (isFind.IsFailed)
            return Result.Fail(isFind.Errors.Last().Message);

        await _statementRepository.Remove(isFind.Value.Id, cancellationToken);
        await _statementRepository.SaveChanges(cancellationToken);

        return Result.Ok("Statement success remove");
    }
}