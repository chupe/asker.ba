using System;
using System.Threading.Tasks;
using AskerTracker.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Data;

namespace AskerTracker.Pages.ItemTransactions
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ItemTransaction ItemTransaction { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemTransaction = await _context.ItemTransaction
                .Include(i => i.Lender)
                .Include(i => i.Owner).FirstOrDefaultAsync(m => m.Id == id);

            if (ItemTransaction == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
