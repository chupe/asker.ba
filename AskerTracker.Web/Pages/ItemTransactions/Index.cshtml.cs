using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;

namespace AskerTracker.Pages.ItemTransactions
{
    public class IndexModel : PageModel
    {
        private readonly AskerTracker.Infrastructure.AskerTrackerDbContext _context;

        public IndexModel(AskerTracker.Infrastructure.AskerTrackerDbContext context)
        {
            _context = context;
        }

        public IList<ItemTransaction> ItemTransaction { get;set; }

        public async Task OnGetAsync()
        {
            ItemTransaction = await _context.ItemTransactions
                .Include(i => i.Item)
                .Include(i => i.Lender)
                .Include(i => i.Owner)
                .Include(i => i.Previous).ToListAsync();
        }
    }
}
