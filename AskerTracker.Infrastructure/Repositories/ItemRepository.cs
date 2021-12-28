using System.Linq;
using AskerTracker.Core;

namespace AskerTracker.Data.Repositories
{
    public class ItemRepository : GenericRepository<Item>
    {
        private readonly AskerTrackerDbContext _context;

        public ItemRepository(AskerTrackerDbContext context) : base(context)
        {
            _context = context;
        }

        public override Item Update(Item entity)
        {
            var updated = _context.Item
                .Single(m => m.Id == entity.Id);

            updated.Amount = entity.Amount;
            updated.Name = entity.Name;
            updated.Description = entity.Description;
            updated.LenderId = entity.LenderId;
            updated.OwnerId = entity.OwnerId;
            updated.Value = entity.Value;
            updated.IsTeamProperty = entity.IsTeamProperty;

            return base.Update(updated);
        }
    }
}