using AskerTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AskerTracker.Persistence.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members");

        builder.Property(m => m.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(m => m.LastName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(m => m.Nickname)
            .HasMaxLength(50);

        builder.Property(m => m.Jmbg)
            .IsRequired()
            .HasMaxLength(13);
        
        builder.Property(m => m.CreatedDate)
            .IsRequired();

        builder.Property(m => m.DateJoined)
            .IsRequired();
        
        builder.Property(m => m.BirthDate)
            .IsRequired();

        builder.Property(m => m.PhoneNumber)
            .IsRequired();
        
        builder.Property(m => m.BloodType)
            .HasColumnType("BloodType");
        
    }
}