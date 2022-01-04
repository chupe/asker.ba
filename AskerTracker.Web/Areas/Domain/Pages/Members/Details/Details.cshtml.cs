using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.Members.Details;

public class DetailsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DetailsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public Member Member { get; set; }

    [BindProperty(SupportsGet = true)] public Guid MemberFilter { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? memberFilter)
    {
        if (memberFilter == null) return NotFound();

        Member = await _context.Members.FirstOrDefaultAsync(m => m.Id == memberFilter);

        if (Member == null) return NotFound();
        
        return Page();
    }
}