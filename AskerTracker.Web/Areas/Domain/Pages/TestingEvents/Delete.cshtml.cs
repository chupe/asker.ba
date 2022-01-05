using System;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.TestingEvents;

public class DeleteModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TestingEvent TestingEvent { get; set; }

    public string ReturnUrl { get; set; }
    
    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        TestingEvent = await _context.TestingEvents
            .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

        if (TestingEvent == null) return NotFound();
        
        ReturnUrl = Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }


    public async Task<IActionResult> OnPostAsync(Guid? id, string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (id == null) return NotFound();

        TestingEvent = await _context.TestingEvents.FindAsync(id);

        if (TestingEvent != null)
        {
            _context.TestingEvents.Remove(TestingEvent);
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Removed event held on {TestingEvent.DateHeld} successfully!";
        }

        return LocalRedirect(returnUrl);
    }
}