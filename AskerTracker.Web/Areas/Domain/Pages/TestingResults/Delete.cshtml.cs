using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.TestingResults;

public class DeleteModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
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
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id, string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (id == null) return NotFound();

        TestingResult = await _context.TestingResults
            .Include(r => r.Member)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (TestingResult != null)
        {
            _context.TestingResults.Remove(TestingResult);
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Removed testing result for {TestingResult.Member.FullName} successfully!";
        }

        return LocalRedirect(returnUrl);
    }
}