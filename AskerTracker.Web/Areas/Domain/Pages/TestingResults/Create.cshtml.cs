using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Web.Areas.Domain.Pages.TestingResults;

public class CreateModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public CreateModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TestingResult TestingResult { get; set; }

    public IActionResult OnGet()
    {
        ViewData["EventId"] = new SelectList(_context.TestingEvents, "Id", "Id");
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "FirstName");
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.TestingResults.Add(TestingResult);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}