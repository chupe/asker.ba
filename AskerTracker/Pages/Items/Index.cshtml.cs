using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Data;

namespace AskerTracker.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Item
                .Include(i => i.Lender)
                .Include(i => i.Owner).ToListAsync();
        }
    }
}
