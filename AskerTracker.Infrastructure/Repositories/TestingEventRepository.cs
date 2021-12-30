using System.Linq;
using AskerTracker.Domain;

namespace AskerTracker.Infrastructure.Repositories
{
    public class TestingEventRepository : GenericRepository<TestingEvent>
    {
        private readonly AskerTrackerDbContext _context;

        public TestingEventRepository(AskerTrackerDbContext context) : base(context)
        {
            _context = context;
        }

        public override TestingEvent Update(TestingEvent entity)
        {
            var updated = _context.TestingEvents
                .Single(m => m.Id == entity.Id);

            updated.LocationId = entity.LocationId;
            updated.Participants = entity.Participants;
            updated.DateHeld = entity.DateHeld;

            return base.Update(updated);
        }
    }
}