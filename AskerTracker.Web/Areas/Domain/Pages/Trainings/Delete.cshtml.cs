using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.Trainings;

public class DeleteModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
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
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        Training = await _context.Trainings.FindAsync(id);

        if (Training != null)
        {
            _context.Trainings.Remove(Training);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}