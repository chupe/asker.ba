using System.Linq;
using AskerTracker.Domain;

namespace AskerTracker.Infrastructure.Repositories
{
    public class TrainingRepository : GenericRepository<Training>
    {
        private readonly AskerTrackerDbContext _context;

        public TrainingRepository(AskerTrackerDbContext context) : base(context)
        {
            _context = context;
        }

        public override Training Update(Training entity)
        {
            var updated = _context.Trainings
                .Single(m => m.Id == entity.Id);

            updated.TrainingType = entity.TrainingType;
            updated.LocationId = entity.LocationId;
            updated.Participants = entity.Participants;
            updated.DateHeld = entity.DateHeld;

            return base.Update(updated);
        }
    }
}