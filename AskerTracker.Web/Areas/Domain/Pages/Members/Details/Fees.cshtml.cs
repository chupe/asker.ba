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

public class FeesModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public FeesModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<MembershipFee> MembershipFees { get; set; }

    [BindProperty(SupportsGet = true)] public Guid? MemberFilter { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (MemberFilter == null) return NotFound();

        var memberExists = await _context.Members.AnyAsync(m => m.Id == MemberFilter);

        if (!memberExists) return NotFound();

        MembershipFees = await _context.MembershipFees.Where(x => x.MemberId == MemberFilter)
            .OrderByDescending(f => f.TransactionDate)
            .Include(m => m.Member)
            .ToListAsync();

        return Page();
    }
}