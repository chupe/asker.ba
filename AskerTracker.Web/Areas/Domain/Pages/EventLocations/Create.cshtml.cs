using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AskerTracker.Web.Areas.Domain.Pages.EventLocations;

public class CreateModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public CreateModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public EventLocation EventLocation { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.EventLocations.Add(EventLocation);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}