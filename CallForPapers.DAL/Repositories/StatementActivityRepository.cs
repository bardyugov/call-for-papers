using CallForPapers.Contracts.Repositories;
using CallForPapers.Domain.Models;
using CallForPapers.DAL.Database;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CallForPapers.DAL.Repositories;

public class StatementActivityRepository(DatabaseContext context) : IStatementActivityRepository
{
    public async Task<Result<StatementActivity>> FindByName(string name, CancellationToken token)
    {
        var result = await context.Activities
            .FirstOrDefaultAsync(v => v.Name == name, token);
        return result is null ? Result.Fail("Not found activity") : Result.Ok(result);
    }

    public async Task<List<StatementActivity>> Find(CancellationToken token)
    {
        return await context.Activities.ToListAsync(token);
    }
}