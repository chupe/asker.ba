using System;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain.Entities;
using AskerTracker.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.EventLocations;

public class EditModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public EditModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public EventLocation EventLocation { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id, string returnUrl = null)
    {
        if (id == null) return NotFound();

        EventLocation = await _context.EventLocations.FirstOrDefaultAsync(m => m.Id == id);

        if (EventLocation == null) return NotFound();
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(EventLocation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventLocationExists(EventLocation.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool EventLocationExists(Guid id)
    {
        return _context.EventLocations.Any(e => e.Id == id);
    }
}