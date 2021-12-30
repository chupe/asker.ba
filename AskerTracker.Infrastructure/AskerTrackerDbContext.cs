using System;
using AskerTracker.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Infrastructure
{
    public class Role : IdentityRole<Guid> { }

    public class AskerTrackerDbContext : IdentityDbContext<Member, Role, Guid>
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
    }
}