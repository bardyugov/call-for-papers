using CallForPapers.Domain.Models;
using FluentResults;

namespace CallForPapers.Contracts.Repositories;

public interface IStatementActivityRepository
{
    Task<Result<StatementActivity>> FindByName(string name, CancellationToken token);
    
    Task<List<StatementActivity>> Find(CancellationToken token);
}