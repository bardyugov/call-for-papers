using CallForPapers.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallForPapers.DAL.Database.EntitiesConfigurations;

public class StatementConfiguration : IEntityTypeConfiguration<Statement>
{
    public void Configure(EntityTypeBuilder<Statement> builder)
    {
        builder.ToTable("Statements").HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(300);
        builder.Property(p => p.Outline).IsRequired().HasMaxLength(1000);
        builder.Property(p => p.Author).IsRequired();
        builder.Property(p => p.Status).IsRequired();
        builder.Property(p => p.CreateDate).IsRequired();
        builder.Property(p => p.SubmittedTime);
        builder
            .HasOne<StatementActivity>(p => p.Activity)
            .WithMany(v => v.Statements)
            .IsRequired();
    }
}