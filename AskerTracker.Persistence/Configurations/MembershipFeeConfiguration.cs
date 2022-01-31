using AskerTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AskerTracker.Persistence.Configurations;

public class MembershipFeeConfiguration : IEntityTypeConfiguration<MembershipFee>
{
    public void Configure(EntityTypeBuilder<MembershipFee> builder)
    {
        builder.Property(f => f.MemberId)
            .IsRequired();
        
        builder.Property(f => f.Amount)
            .IsRequired()
            .HasPrecision(14, 2);
        
        builder.Property(f => f.TransactionDate)
            .IsRequired();

        builder.Property(m => m.CreatedDate)
            .IsRequired();
    }
}