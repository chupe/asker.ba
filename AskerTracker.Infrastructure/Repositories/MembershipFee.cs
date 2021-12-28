using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AskerTracker.Core;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Data.Repositories
{
    public class MembershipFeeRepository : GenericRepository<MembershipFee>
    {
        private readonly AskerTrackerDbContext _context;

        public MembershipFeeRepository(AskerTrackerDbContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<MembershipFee> Find(Expression<Func<MembershipFee, bool>> predicate)
        {
            return _context.MembershipFee
                .Include(f => f.Member)
                .Where(predicate)
                .ToList();
        }

        public override MembershipFee Update(MembershipFee entity)
        {
            var updated = _context.MembershipFee
                .Single(m => m.Id == entity.Id);

            updated.Amount = entity.Amount;
            updated.TransactionDate = entity.TransactionDate;
            updated.MemberId = entity.MemberId;

            return base.Update(updated);
        }
    }
}