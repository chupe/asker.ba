using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Trainings
{
    public class IndexModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public IndexModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        public IList<Training> Training { get; set; }

        public async Task OnGetAsync()
        {
            Training = await _context.Training
                .Include(t => t.Location).ToListAsync();
        }
    }
}