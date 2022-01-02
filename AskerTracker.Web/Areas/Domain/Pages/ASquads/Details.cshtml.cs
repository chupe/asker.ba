using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.ASquads;

public class DetailsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DetailsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public ASquad ASquad { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        ASquad = await _context.ASquads.FirstOrDefaultAsync(m => m.Id == id);

        if (ASquad == null) return NotFound();
        return Page();
    }
}