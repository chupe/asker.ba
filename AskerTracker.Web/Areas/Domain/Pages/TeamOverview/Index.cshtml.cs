using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using AskerTracker.Web.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.TeamOverview;

public class IndexModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public IndexModel(AskerTrackerDbContext context)
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