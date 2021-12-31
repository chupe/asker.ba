using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Infrastructure
{
    public class AskerTrackerDbContextNoTracking : AskerTrackerDbContext
    {
        public AskerTrackerDbContextNoTracking(DbContextOptions<AskerTrackerDbContext> options)
            : base(options)
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}