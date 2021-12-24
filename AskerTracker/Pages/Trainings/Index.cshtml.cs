using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Data;

namespace AskerTracker.Pages.Trainings
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Training> Training { get;set; }

        public async Task OnGetAsync()
        {
            Training = await _context.Training
                .Include(t => t.Location).ToListAsync();
        }
    }
}
