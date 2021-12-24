using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Data;

namespace AskerTracker.Pages.ASquads
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ASquad> ASquad { get;set; }

        public async Task OnGetAsync()
        {
            ASquad = await _context.ASquad.ToListAsync();
        }
    }
}
