using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.Trainings;

public class DetailsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DetailsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public Training Training { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        Training = await _context.Trainings
            .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

        if (Training == null) return NotFound();
        return Page();
    }
}