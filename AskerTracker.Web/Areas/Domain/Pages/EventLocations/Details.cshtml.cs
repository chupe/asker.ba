using System;
using System.Threading.Tasks;
using AskerTracker.Web.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.EventLocations;

public class DetailsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DetailsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public EventLocation EventLocation { get; set; }
    
    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id, string returnUrl = null)
    {
        if (id == null) return NotFound();

        EventLocation = await _context.EventLocations.FirstOrDefaultAsync(m => m.Id == id);

        if (EventLocation == null) return NotFound();
        
        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }
}