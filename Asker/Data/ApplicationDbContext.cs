using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Asker.Models;

namespace Asker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Asker.Models.Item> Item { get; set; }
        public DbSet<Asker.Models.Member> Member { get; set; }
        public DbSet<Asker.Models.MembershipFee> MembershipFee { get; set; }
        public DbSet<Asker.Models.Training> Training { get; set; }
        public DbSet<Asker.Models.TestingEvent> TestingEvent { get; set; }
        public DbSet<Asker.Models.TestingResult> TestingResult { get; set; }
        public DbSet<Asker.Models.EventLocation> EventLocation { get; set; }
        public DbSet<Asker.Models.ItemTransaction> ItemTransaction { get; set; }
        public DbSet<Asker.Models.ASquad> ASquad { get; set; }
    }
}
