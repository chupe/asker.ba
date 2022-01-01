using System;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Trainings;

public class EditModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public EditModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Training Training { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        Training = await _context.Trainings
            .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

        if (Training == null) return NotFound();
        ViewData["LocationId"] = new SelectList(_context.EventLocations, "Id", "Location");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Training).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TrainingExists(Training.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool TrainingExists(Guid id)
    {
        return _context.Trainings.Any(e => e.Id == id);
    }
}