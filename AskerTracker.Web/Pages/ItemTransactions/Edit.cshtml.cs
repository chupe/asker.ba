using System;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.ItemTransactions
{
    public class EditModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public EditModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty] public ItemTransaction ItemTransaction { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            ItemTransaction = await _context.ItemTransactions
                .Include(i => i.Lender)
                .Include(i => i.Owner).FirstOrDefaultAsync(m => m.Id == id);

            if (ItemTransaction == null) return NotFound();
            ViewData["LenderId"] = new SelectList(_context.Members, "Id", "FirstName");
            ViewData["OwnerId"] = new SelectList(_context.Members, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(ItemTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTransactionExists(ItemTransaction.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool ItemTransactionExists(Guid id)
        {
            return _context.ItemTransactions.Any(e => e.Id == id);
        }
    }
}