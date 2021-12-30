using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.TestingEvents
{
    public class IndexModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public IndexModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        public IList<TestingEvent> TestingEvent { get; set; }

        public async Task OnGetAsync()
        {
            TestingEvent = await _context.TestingEvents
                .Include(t => t.Location).ToListAsync();
        }
    }
}