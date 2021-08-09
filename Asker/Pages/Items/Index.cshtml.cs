using System.Collections.Generic;
using System.Threading.Tasks;
using Asker.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Asker.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public IndexModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get; set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Item.ToListAsync();
        }
    }
}
