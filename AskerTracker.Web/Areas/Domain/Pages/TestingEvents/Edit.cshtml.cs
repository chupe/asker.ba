using System;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.TestingEvents;

public class EditModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public EditModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TestingEvent TestingEvent { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        TestingEvent = await _context.TestingEvents
            .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

        if (TestingEvent == null) return NotFound();
        ViewData["LocationId"] = new SelectList(_context.EventLocations, "Id", "Location");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(TestingEvent).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TestingEventExists(TestingEvent.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool TestingEventExists(Guid id)
    {
        return _context.TestingEvents.Any(e => e.Id == id);
    }
}