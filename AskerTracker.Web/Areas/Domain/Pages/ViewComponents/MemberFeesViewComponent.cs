using System.Threading.Tasks;
using AskerTracker.Areas.Domain.Pages.MembershipFees;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AskerTracker.Areas.Domain.Pages.ViewComponents;

public class MemberFeesViewComponent : ViewComponent
{
    private readonly AskerTrackerDbContext _dbContext;

    public MemberFeesViewComponent(AskerTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task<IViewComponentResult> InvokeAsync(string memberId)
    {
        var membershipFeeModel = new IndexModel(_dbContext)
        {
            MemberFilter = memberId
        };

        await membershipFeeModel.OnGetAsync();
            
        return View(membershipFeeModel);
    }
}