using CallForPapers.Domain.Models;
using FluentResults;

namespace CallForPapers.Application.Repositories;

public interface IStatementActivityRepository : IBaseRepository
{
    Task<Result<StatementActivity>> FindByName(string name, CancellationToken token);
    
    Task<List<StatementActivity>> Find(CancellationToken token);
}