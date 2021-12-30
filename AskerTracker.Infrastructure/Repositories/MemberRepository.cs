using System.Linq;
using AskerTracker.Domain;

namespace AskerTracker.Infrastructure.Repositories
{
    public class MemberRepository : GenericRepository<Member>
    {
        private readonly AskerTrackerDbContext _context;

        public MemberRepository(AskerTrackerDbContext context) : base(context)
        {
            _context = context;
        }

        public override Member Update(Member entity)
        {
            var updated = _context.Members
                .Single(m => m.Id == entity.Id);

            updated.Active = entity.Active;
            updated.FirstName = entity.FirstName;
            updated.LastName = entity.LastName;
            updated.Nickname = entity.Nickname;
            updated.Email = entity.Email;
            updated.DateLeft = entity.DateLeft;
            updated.BloodType = entity.BloodType;
            updated.PhoneNumber = entity.PhoneNumber;

            return base.Update(updated);
        }
    }
}