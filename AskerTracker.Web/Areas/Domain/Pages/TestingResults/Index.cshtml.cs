using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.TestingResults;

public class IndexModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public IndexModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<TestingResult> TestingResult { get; set; }

    public async Task OnGetAsync()
    {
        TestingResult = await _context.TestingResults
            .Include(t => t.Event)
            .Include(t => t.Member).ToListAsync();
    }
}