using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.TestingEvents;

public class DeleteModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
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
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        TestingEvent = await _context.TestingEvents.FindAsync(id);

        if (TestingEvent != null)
        {
            _context.TestingEvents.Remove(TestingEvent);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}