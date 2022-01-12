using System;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.TestingResults;

public class EditModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public EditModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TestingResult TestingResult { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id, string returnUrl = null)
    {
        if (id == null) return NotFound();

        TestingResult = await _context.TestingResults
            .Include(t => t.Event)
            .Include(t => t.Member).FirstOrDefaultAsync(m => m.Id == id);

        if (TestingResult == null) return NotFound();
        ViewData["EventId"] = new SelectList(_context.TestingEvents, "Id", "Id");
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "FirstName");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(TestingResult).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TestingResultExists(TestingResult.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool TestingResultExists(Guid id)
    {
        return _context.TestingResults.Any(e => e.Id == id);
    }
}