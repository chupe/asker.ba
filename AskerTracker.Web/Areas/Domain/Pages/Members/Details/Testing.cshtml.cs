using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Web.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.Members.Details;

public class TestingsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public TestingsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<TestingEvent> TestingEvents { get; set; }

    [BindProperty(SupportsGet = true)] public Guid? MemberFilter { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (MemberFilter == null) return NotFound();

        var memberExists = await _context.Members.AnyAsync(m => m.Id == MemberFilter);

        if (!memberExists) return NotFound();
        
        TestingEvents = await _context.TestingEvents.Where(e => e.Participants.Any(m => m.Id == MemberFilter))
            .OrderByDescending(y => y.DateHeld)
            .Include(x => x.Participants)
            .Include(t => t.Location)
            .ToListAsync();

        return Page();
    }
}