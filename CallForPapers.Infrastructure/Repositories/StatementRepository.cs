using CallForPapers.Application.Repositories;
using CallForPapers.Domain.Models;
using CallForPapers.Infrastructure.Database;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CallForPapers.Infrastructure.Repositories;

public class StatementRepository : IStatementRepository
{
    private readonly DatabaseContext _databaseContext;

    public StatementRepository(DatabaseContext context) => _databaseContext = context;

    public async Task Create(Statement statement, CancellationToken token)
    {
        await _databaseContext.Statements.AddAsync(statement, token);
    }

    public async Task<Result> Remove(Guid id, CancellationToken token)
    {
        var result = await FindById(id, token);
        if (result.IsFailed)
            return Result.Fail(result.Errors.Last().Message);

        _databaseContext.Statements.Remove(result.Value);
        return Result.Ok();
    }

    public async Task<Result> Update(Statement statement, CancellationToken token)
    {
        var result = await FindById(statement.Id, token);
        if (result.IsFailed)
            return Result.Fail("");

        _databaseContext.Statements.Update(result.Value);
        return Result.Ok();
    }

    public async Task<Result<Statement>> FindById(Guid id, CancellationToken token)
    {
        var statement = await _databaseContext.Statements
            .Include(v => v.Activity)
            .FirstOrDefaultAsync(v => v.Id == id, token);
        if (statement is null)
            return Result.Fail("Not found statement");

        return Result.Ok(statement);
    }

    public Task<List<Statement>> FindByAuthorId(Guid author, CancellationToken token)
    {
        return _databaseContext.Statements.Where(v => v.Author == author).ToListAsync(token);
    }

    public Task<List<Statement>> FindByStatus(Status status, CancellationToken token)
    {
        return _databaseContext.Statements
            .Include(v => v.Activity)
            .Where(v => v.Status == status)
            .ToListAsync(token);
    }

    public async Task<Result<Statement>> FindByAuthorIdUnconfirmedStatement(Guid id, CancellationToken token)
    {
        var result = await _databaseContext.Statements
            .Include(v => v.Activity)
            .FirstOrDefaultAsync(v => v.Author == id && v.Status == Status.Unconfirmed, token);
        if (result is null)
            return Result.Fail("Not found statement");

        return Result.Ok(result);
    }

    public async Task SaveChanges(CancellationToken token)
    {
        await _databaseContext.SaveChangesAsync(token);
    }
}