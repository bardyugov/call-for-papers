using CallForPapers.Domain.Models;
using FluentResults;

namespace CallForPapers.Contracts.Repositories;

public interface IStatementRepository
{
    Task Create(Statement statement, CancellationToken token);
    
    Task<Result> Remove(Guid id, CancellationToken token);

    Task<Result<Statement>> FindById(Guid id, CancellationToken token); 

    Task<List<Statement>> FindByAuthorId(Guid author, CancellationToken token);

    Task<List<Statement>> FindByStatus(Status status, CancellationToken token);
    
    Task<Result> Update(Statement statement, CancellationToken token);
    
    Task<Result<Statement>> FindByAuthorIdUnconfirmed(Guid id, CancellationToken token);
}