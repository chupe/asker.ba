using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Items;

public class IndexModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public IndexModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<Item> Item { get; set; }

    public async Task OnGetAsync()
    {
        Item = await _context.Items
            .Include(i => i.Lender)
            .Include(i => i.Owner).ToListAsync();
    }
}