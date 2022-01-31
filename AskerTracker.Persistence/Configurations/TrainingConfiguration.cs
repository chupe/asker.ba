using AskerTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AskerTracker.Persistence.Configurations;

public class TrainingConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.Property(training => training.TrainingType)
            .IsRequired()
            .HasColumnType("TrainingType");
        
        builder.Property(training => training.LocationId)
            .IsRequired();

        builder.Property(training => training.CreatedDate)
            .IsRequired();
        
        builder.Property(training => training.DateHeld)
            .IsRequired();
    }
}