using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.TestingResults
{
    public class IndexModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public IndexModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        public IList<TestingResult> TestingResult { get; set; }

        public async Task OnGetAsync()
        {
            TestingResult = await _context.TestingResult
                .Include(t => t.Event)
                .Include(t => t.Member).ToListAsync();
        }
    }
}