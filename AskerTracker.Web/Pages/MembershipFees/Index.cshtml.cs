using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees;

public class IndexModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public IndexModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<MembershipFee> MembershipFee { get; set; }

    public async Task OnGetAsync()
    {
        MembershipFee = await _context.MembershipFees
            .Include(m => m.Member).ToListAsync();
    }
}