using CallForPapers.DAL.Database.EntitiesConfigurations;
using CallForPapers.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CallForPapers.DAL.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Statement> Statements { get; private set; } = null!;

    public DbSet<StatementActivity> Activities { get; private set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StatementConfiguration());
        modelBuilder.ApplyConfiguration(new StatementActivityConfiguration());
    }
}