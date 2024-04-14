using CallForPapers.Contracts.Repositories;
using CallForPapers.DAL.Database;
using CallForPapers.Domain.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CallForPapers.DAL.Repositories;

public class StatementRepository(DatabaseContext context) : IStatementRepository
{
    public async Task Create(Statement statement, CancellationToken token)
    {
        await context.Statements.AddAsync(statement, token);
        await context.SaveChangesAsync(token);
    }

    public async Task<Result> Remove(Guid id, CancellationToken token)
    {
        var result = await FindById(id, token);
        if (result.IsFailed)
            return Result.Fail(result.Errors.Last().Message);

        context.Statements.Remove(result.Value);
        await context.SaveChangesAsync(token);
        return Result.Ok();
    }

    public async Task<Result> Update(Statement statement, CancellationToken token)
    {
        var result = await FindById(statement.Id, token);
        if (result.IsFailed)
            return Result.Fail("");

        context.Statements.Update(result.Value);
        await context.SaveChangesAsync(token);
        return Result.Ok();
    }

    public async Task<Result<Statement>> FindById(Guid id, CancellationToken token)
    {
        var statement = await context.Statements
            .Include(v => v.Activity)
            .FirstOrDefaultAsync(v => v.Id == id, token);
        return statement is null ? Result.Fail("Not found statement") : Result.Ok(statement);
    }

    public async Task<List<Statement>> FindByAuthorId(Guid author, CancellationToken token)
    {
        return await context.Statements.Where(v => v.Author == author).ToListAsync(token);
    }

    public async Task<List<Statement>> FindByStatus(Status status, CancellationToken token)
    {
        return await context.Statements
            .Include(v => v.Activity)
            .Where(v => v.Status == status)
            .ToListAsync(token);
    }

    public async Task<Result<Statement>> FindByAuthorIdUnconfirmed(Guid id, CancellationToken token)
    {
        var result = await context.Statements
            .Include(v => v.Activity)
            .FirstOrDefaultAsync(v => v.Author == id && v.Status == Status.Unconfirmed, token);
        return result is null ? Result.Fail("Not found statement") : Result.Ok(result);
    }
}