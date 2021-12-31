using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;

namespace AskerTracker.Pages.TestingResults
{
    public class IndexModel : PageModel
    {
        private readonly AskerTracker.Infrastructure.AskerTrackerDbContext _context;

        public IndexModel(AskerTracker.Infrastructure.AskerTrackerDbContext context)
        {
            _context = context;
        }

        public IList<TestingResult> TestingResult { get;set; }

        public async Task OnGetAsync()
        {
            TestingResult = await _context.TestingResults
                .Include(t => t.Event)
                .Include(t => t.Member).ToListAsync();
        }
    }
}
