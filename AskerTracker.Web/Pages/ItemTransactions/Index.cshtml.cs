using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.ItemTransactions;

public class IndexModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public IndexModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<ItemTransaction> ItemTransaction { get; set; }

    public async Task OnGetAsync()
    {
        ItemTransaction = await _context.ItemTransactions
            .Include(i => i.Item)
            .Include(i => i.Lender)
            .Include(i => i.Owner)
            .Include(i => i.Previous).ToListAsync();
    }
}