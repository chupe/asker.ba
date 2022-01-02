using System;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using AskerTracker.Pages.MembershipFees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.ViewComponents
{
    public class MemberFeesViewComponent : ViewComponent
    {
        private readonly AskerTrackerDbContext _dbContext;

        public MemberFeesViewComponent(AskerTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(string memberId, string returnUrl)
        {
            var membershipFeeModel = new IndexModel(_dbContext)
            {
                MemberFilter = memberId
            };

            await membershipFeeModel.OnGetAsync();
            ViewData["Referer"] = Request.Headers["Referer"].ToString().ToRelativePath();
            
            return View(membershipFeeModel);
        }
    }
}