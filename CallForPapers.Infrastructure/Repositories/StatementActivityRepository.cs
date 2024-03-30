using CallForPapers.Application.Repositories;
using CallForPapers.Domain.Models;
using CallForPapers.Infrastructure.Database;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CallForPapers.Infrastructure.Repositories;

public class StatementActivityRepository : IStatementActivityRepository
{
    private readonly DatabaseContext _databaseContext;

    public StatementActivityRepository(DatabaseContext context) => _databaseContext = context;

    public async Task<Result<StatementActivity>> FindByName(string name, CancellationToken token)
    {
        var result = await _databaseContext.Activities
            .FirstOrDefaultAsync(v => v.Name == name, token);
        if (result is null)
            return Result.Fail("Not found activity");

        return Result.Ok(result);
    }

    public async Task<List<StatementActivity>> Find(CancellationToken token)
    {
        return await _databaseContext.Activities.ToListAsync(token);
    }

    public async Task SaveChanges(CancellationToken token)
    {
        await _databaseContext.SaveChangesAsync(token);
    }
}