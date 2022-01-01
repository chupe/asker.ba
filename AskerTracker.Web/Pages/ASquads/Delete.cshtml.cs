using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.ASquads;

public class DeleteModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public ASquad ASquad { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        ASquad = await _context.ASquads.FirstOrDefaultAsync(m => m.Id == id);

        if (ASquad == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        ASquad = await _context.ASquads.FindAsync(id);

        if (ASquad != null)
        {
            _context.ASquads.Remove(ASquad);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}