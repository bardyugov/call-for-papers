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

    public Task<Result<Statement>> Update(Guid id, Statement statement, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Statement>> FindById(Guid id, CancellationToken token)
    {
        var statement = await _databaseContext.Statements.FirstOrDefaultAsync(v => v.Id == id, token);
        if (statement is null)
            return Result.Fail("Not found statement");

        return Result.Ok(statement);
    }

    public async Task<List<Statement>> FindByAuthorId(Guid author, CancellationToken token)
    {
        return await _databaseContext.Statements.Where(v => v.Author == author).ToListAsync(token);
    }

    public async Task<List<Statement>> FindByAuthorIdUnconfirmedStatements(Guid id, CancellationToken token)
    {
        return await _databaseContext.Statements
            .Where(v => v.Id == id && v.Status == Status.Unconfirmed)
            .ToListAsync(token);
    }

    public async Task SaveChanges(CancellationToken token)
    {
        await _databaseContext.SaveChangesAsync(token);
    }
}