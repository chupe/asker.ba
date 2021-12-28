using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.ViewComponents
{
    public class MembersCountViewComponent : ViewComponent
    {
        private readonly AskerTrackerDbContext _dbContext;

        public MembersCountViewComponent(AskerTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            var count = await _dbContext.Member.CountAsync();
            
            return View(count + (title?.Length ?? 0));
        }
    }
}