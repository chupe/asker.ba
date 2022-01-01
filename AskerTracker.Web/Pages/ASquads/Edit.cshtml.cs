using System;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.ASquads;

public class EditModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public EditModel(AskerTrackerDbContext context)
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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(ASquad).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ASquadExists(ASquad.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ASquadExists(Guid id)
    {
        return _context.ASquads.Any(e => e.Id == id);
    }
}