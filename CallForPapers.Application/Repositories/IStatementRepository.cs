using CallForPapers.Domain.Models;
using FluentResults;

namespace CallForPapers.Application.Repositories;

public interface IStatementRepository : IBaseRepository
{
    Task Create(Statement statement, CancellationToken token);
    
    Task<Result> Remove(Guid id, CancellationToken token);

    Task<Result<Statement>> FindById(Guid id, CancellationToken token); 

    Task<List<Statement>> FindByAuthorId(Guid author, CancellationToken token);

    Task<Result<Statement>> Update(Guid id, Statement statement, CancellationToken token);
    
    Task<List<Statement>> FindByAuthorIdUnconfirmedStatements(Guid id, CancellationToken token);
}