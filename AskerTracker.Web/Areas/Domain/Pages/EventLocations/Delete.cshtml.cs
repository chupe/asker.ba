using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.EventLocations;

public class DeleteModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
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

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        EventLocation = await _context.EventLocations.FindAsync(id);

        if (EventLocation != null)
        {
            _context.EventLocations.Remove(EventLocation);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}