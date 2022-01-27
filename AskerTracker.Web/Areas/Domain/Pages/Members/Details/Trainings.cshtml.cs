using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.Members.Details;

public class TrainingsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public TrainingsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<Training> Trainings { get; set; }

    [BindProperty(SupportsGet = true)] public Guid? MemberFilter { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (MemberFilter == null) return NotFound();

        var memberExists = await _context.Members.AnyAsync(m => m.Id == MemberFilter);

        if (!memberExists) return NotFound();
        
        Trainings = await _context.Trainings.Where(e => e.Participants.Any(m => m.Id == MemberFilter))
            .OrderByDescending(y => y.DateHeld)
            .Include(t => t.Location)
            .Include(x => x.Participants.Where(m => m.Id == MemberFilter))
            .ToListAsync();

        return Page();
    }
}