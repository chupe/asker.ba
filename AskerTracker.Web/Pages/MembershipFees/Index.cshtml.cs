using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees
{
    public class IndexModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public IndexModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        public IList<MembershipFee> MembershipFee { get; set; }

        public SelectList Members { get; set; }

        [BindProperty(SupportsGet = true)] public string Member { get; set; }

        public async Task OnGetAsync()
        {
            var membersQuery = _context.MembershipFee.OrderBy(m => m.Member.FullName).Select(n => n.Member.FullName);

            var fees = await _context.MembershipFee
                .Include(m => m.Member).ToListAsync();

            if (!string.IsNullOrEmpty(Member)) fees = fees.Where(x => x.Member.FullName == Member).ToList();
            Members = new SelectList(await membersQuery.Distinct().ToListAsync());

            MembershipFee = fees;
        }
    }
}