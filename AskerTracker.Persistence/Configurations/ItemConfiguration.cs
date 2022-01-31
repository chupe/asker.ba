using AskerTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AskerTracker.Persistence.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(item => item.Amount)
            .IsRequired();
        
        builder.Property(item => item.Value)
            .IsRequired()
            .HasPrecision(8, 2);

        builder.Property(item => item.CreatedDate)
            .IsRequired();
        
        builder.Property(item => item.LastTransactionDate)
            .IsRequired();
    }
}