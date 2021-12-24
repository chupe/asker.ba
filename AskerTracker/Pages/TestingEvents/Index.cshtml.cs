using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.TestingEvents
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TestingEvent> TestingEvent { get; set; }

        public async Task OnGetAsync()
        {
            TestingEvent = await _context.TestingEvent
                .Include(t => t.Location).ToListAsync();
        }
    }
}