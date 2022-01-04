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

    [BindProperty(SupportsGet = true)] public Guid MemberFilter => Member.Id;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        Member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);

        if (Member == null) return NotFound();
        return Page();
    }
}