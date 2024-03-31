using CallForPapers.Domain.Models;
using CallForPapers.Infrastructure.Literals;
using Microsoft.EntityFrameworkCore;

namespace CallForPapers.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Statement> Statements { get; set; }
    public DbSet<StatementActivity> Activities { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<StatementActivity>()
            .HasData( new StatementActivity("Report", "Доклад, 35-45 минут"),
                new StatementActivity("Masterclass", "Мастеркласс, 1-2 часа"),
                new StatementActivity("Discussion", "Дискуссия / круглый стол, 40-50 минут")
                );
    }
}