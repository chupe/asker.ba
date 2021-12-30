using System.Linq;
using AskerTracker.Domain;

namespace AskerTracker.Infrastructure.Repositories
{
    public class EventLocationRepository : GenericRepository<EventLocation>
    {
        private readonly AskerTrackerDbContext _context;

        public EventLocationRepository(AskerTrackerDbContext context) : base(context)
        {
            _context = context;
        }

        public override EventLocation Update(EventLocation entity)
        {
            var updated = _context.EventLocations
                .Single(m => m.Id == entity.Id);

            updated.Location = entity.Location;

            return base.Update(updated);
        }
    }
}