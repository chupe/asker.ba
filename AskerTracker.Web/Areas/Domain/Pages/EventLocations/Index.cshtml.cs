using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain.Entities;
using AskerTracker.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.EventLocations;

public class IndexModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public IndexModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<EventLocation> EventLocation { get; set; }

    public async Task OnGetAsync()
    {
        EventLocation = await _context.EventLocations.ToListAsync();
    }
}