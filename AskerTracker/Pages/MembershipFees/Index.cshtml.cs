using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.MembershipFees
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MembershipFee> MembershipFee { get;set; }

        public SelectList Members { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Member { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.MembershipFee
                                            orderby m.Member.FullName
                                            select m.Member.FullName;

            var fees = await _context.MembershipFee
                .Include(m => m.Member).ToListAsync(); 
            //from m in _context.MembershipFee
            //             select m;

            if (!string.IsNullOrEmpty(Member))
            {
                fees = fees.Where(x => x.Member.FullName == Member).ToList();
            }
            Members = new SelectList(await genreQuery.Distinct().ToListAsync());

            MembershipFee = fees;
        }
    }
}
