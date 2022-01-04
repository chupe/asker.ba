using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.Members.Details;

public class TestingsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public TestingsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<TestingEvent> TestingEvents { get; set; }

    [BindProperty(SupportsGet = true)] public Guid MemberFilter { get; set; }

    public async Task OnGetAsync()
    {
        TestingEvents = await _context.TestingEvents.Where(e => e.Participants.Any(m => m.Id == MemberFilter))
            .OrderByDescending(y => y.DateHeld)
            .Include(x => x.Participants)
            .Include(t => t.Location)
            .ToListAsync();
    }
}