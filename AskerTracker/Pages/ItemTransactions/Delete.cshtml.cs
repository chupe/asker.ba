using System;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.ItemTransactions
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public ItemTransaction ItemTransaction { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            ItemTransaction = await _context.ItemTransaction
                .Include(i => i.Lender)
                .Include(i => i.Owner).FirstOrDefaultAsync(m => m.Id == id);

            if (ItemTransaction == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null) return NotFound();

            ItemTransaction = await _context.ItemTransaction.FindAsync(id);

            if (ItemTransaction != null)
            {
                _context.ItemTransaction.Remove(ItemTransaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}