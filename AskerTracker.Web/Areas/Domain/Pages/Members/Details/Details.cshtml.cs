using System;
using System.Threading.Tasks;
using AskerTracker.Web.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.Members.Details;

public class DetailsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DetailsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public Member Member { get; set; }

    [BindProperty(SupportsGet = true)] public Guid? MemberFilter { get; set; }

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (MemberFilter == null) return NotFound();

        Member = await _context.Members.FirstOrDefaultAsync(m => m.Id == MemberFilter);

        if (Member == null) return NotFound();
        
        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }
}