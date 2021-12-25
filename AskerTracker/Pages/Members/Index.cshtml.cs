using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Members
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public IndexModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [TempData]
        public string Message { get; set; }
        public IList<Member> Member { get; set; }

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var nameQuery = from m in _context.Member
                orderby m.FullName
                select m.FullName;

            var members = from m in _context.Member
                select m;

            if (!string.IsNullOrEmpty(SearchString)) members = members.Where(s => s.FullName.Contains(SearchString));

            Member = await members.ToListAsync();
        }
    }
}