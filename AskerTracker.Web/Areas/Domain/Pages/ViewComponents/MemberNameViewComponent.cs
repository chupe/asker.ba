using System;
using System.Threading.Tasks;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AskerTracker.Web.Areas.Domain.Pages.ViewComponents;

public class MemberNameViewComponent : ViewComponent
{
    private readonly AskerTrackerDbContext _context;

    public MemberNameViewComponent(AskerTrackerDbContext context)
    {
        _context = context;
    }
        
    public async Task<IViewComponentResult> InvokeAsync(Guid memberId)
    {
        var member = await _context.Members.FindAsync(memberId);
        
        return View(member);
    }
}