using CallForPapers.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CallForPapers.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Statement> Statements { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }
}