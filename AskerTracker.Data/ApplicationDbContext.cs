using AskerTracker.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<MembershipFee> MembershipFee { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<TestingEvent> TestingEvent { get; set; }
        public DbSet<TestingResult> TestingResult { get; set; }
        public DbSet<EventLocation> EventLocation { get; set; }
        public DbSet<ItemTransaction> ItemTransaction { get; set; }
        public DbSet<ASquad> ASquad { get; set; }
    }
}