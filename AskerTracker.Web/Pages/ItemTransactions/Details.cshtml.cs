using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.ItemTransactions;

public class DetailsModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public DetailsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public ItemTransaction ItemTransaction { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        ItemTransaction = await _context.ItemTransactions
            .Include(i => i.Item)
            .Include(i => i.Lender)
            .Include(i => i.Owner)
            .Include(i => i.Previous).FirstOrDefaultAsync(m => m.Id == id);

        if (ItemTransaction == null) return NotFound();
        return Page();
    }
}