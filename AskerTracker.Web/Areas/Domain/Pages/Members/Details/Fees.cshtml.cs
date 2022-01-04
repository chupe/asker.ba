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

public class FeesModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public FeesModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<MembershipFee> MembershipFees { get; set; }

    [BindProperty(SupportsGet = true)] public Guid MemberFilter { get; set; }

    public async Task OnGetAsync()
    {
        MembershipFees = await _context.MembershipFees.Where(x => x.MemberId == MemberFilter)
            .OrderByDescending(f => f.TransactionDate)
            .Include(m => m.Member)
            .ToListAsync();
    }
}