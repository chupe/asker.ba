using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.MembershipFees;

public class IndexModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public IndexModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<MembershipFee> MembershipFee { get; set; }

    public IEnumerable<SelectListItem> MembersSelectList =>
        Helper.GetSelectList<Member>(_context, m => m.FullName).Result;

    [BindProperty(SupportsGet = true)] public string MemberFilter { get; set; }

    public async Task OnGetAsync()
    {
        var fees = await _context.MembershipFees
            .Include(m => m.Member)
            .OrderByDescending(f => f.TransactionDate)
            .ToListAsync();

        if (!string.IsNullOrEmpty(MemberFilter))
            fees = fees.Where(x => x.Member.Id.ToString() == MemberFilter).ToList();

        MembershipFee = fees;
    }
}