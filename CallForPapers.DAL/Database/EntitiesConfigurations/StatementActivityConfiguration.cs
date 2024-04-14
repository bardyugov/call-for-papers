using CallForPapers.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallForPapers.DAL.Database.EntitiesConfigurations;

public class StatementActivityConfiguration : IEntityTypeConfiguration<StatementActivity>
{
    public void Configure(EntityTypeBuilder<StatementActivity> builder)
    {
        builder.ToTable("Activities").HasKey(v => v.Id);
        builder.Property(v => v.Name).IsRequired();
        builder.Property(v => v.Description).IsRequired();
        
        builder
            .HasData( 
                new StatementActivity(Guid.NewGuid(), "Report", "Доклад, 35-45 минут", []),
                new StatementActivity(Guid.NewGuid(), "Masterclass", "Мастеркласс, 1-2 часа", []),
                new StatementActivity(Guid.NewGuid(), "Discussion", "Дискуссия / круглый стол, 40-50 минут", [])
            );
    }
}