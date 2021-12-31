using System;
using AskerTracker.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Infrastructure
{
    public class AskerTrackerDbContext : IdentityDbContext
    {
        public AskerTrackerDbContext(DbContextOptions<AskerTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MembershipFee> MembershipFees { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TestingEvent> TestingEvents { get; set; }
        public DbSet<TestingResult> TestingResults { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<ItemTransaction> ItemTransactions { get; set; }
        public DbSet<ASquad> ASquads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Member>()
                .HasMany(m => m.Trainings)
                .WithMany(t => t.Participants)
                .UsingEntity<MemberTraining>(
                    mt => mt.HasOne<Training>().WithMany(),
                    mt => mt.HasOne<Member>().WithMany()
                )
                .Property(mt => mt.WasLate)
                .HasDefaultValue(false);
        }
    }

    public class MemberTraining
    {
        public Guid MemberId { get; set; }
        public Guid TrainingId { get; set; }
        public bool WasLate { get; set; }
    }
}