using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Persistence;

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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AskerTrackerDbContext).Assembly);

        builder.Entity<Member>()
            .HasMany(member => member.Trainings)
            .WithMany(training => training.Participants)
            .UsingEntity<MemberTraining>(
                mt => mt.HasOne<Training>().WithMany(),
                mt => mt.HasOne<Member>().WithMany()
            )
            .Property(memberTraining => memberTraining.WasLate)
            .HasDefaultValue(false);
    }
    
    // public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    // {
    //     foreach (var entry in ChangeTracker.Entries<BaseEntity>())
    //     {
    //         switch (entry.State)
    //         {
    //             case EntityState.Added:
    //                 entry.Entity.CreatedDate = DateTime.Now;
    //                 break;
    //             case EntityState.Modified:
    //                 entry.Entity.LastModifiedDate = DateTime.Now;
    //                 break;
    //         }
    //     }
    //     return base.SaveChangesAsync(cancellationToken);
    // }
}

public class MemberTraining
{
    public Guid MemberId { get; set; }
    public Guid TrainingId { get; set; }
    public bool WasLate { get; set; }
}