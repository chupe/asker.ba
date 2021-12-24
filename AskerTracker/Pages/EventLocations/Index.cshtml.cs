using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.EventLocations
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EventLocation> EventLocation { get; set; }

        public async Task OnGetAsync()
        {
            EventLocation = await _context.EventLocation.ToListAsync();
        }
    }
}