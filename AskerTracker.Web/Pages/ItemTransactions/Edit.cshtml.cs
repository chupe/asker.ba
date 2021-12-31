using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;

namespace AskerTracker.Pages.ItemTransactions
{
    public class EditModel : PageModel
    {
        private readonly AskerTracker.Infrastructure.AskerTrackerDbContext _context;

        public EditModel(AskerTracker.Infrastructure.AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ItemTransaction ItemTransaction { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemTransaction = await _context.ItemTransactions
                .Include(i => i.Item)
                .Include(i => i.Lender)
                .Include(i => i.Owner)
                .Include(i => i.Previous).FirstOrDefaultAsync(m => m.Id == id);

            if (ItemTransaction == null)
            {
                return NotFound();
            }
           ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name");
           ViewData["LenderId"] = new SelectList(_context.Members, "Id", "FirstName");
           ViewData["OwnerId"] = new SelectList(_context.Members, "Id", "FirstName");
           ViewData["PreviousId"] = new SelectList(_context.ItemTransactions, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ItemTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTransactionExists(ItemTransaction.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ItemTransactionExists(Guid id)
        {
            return _context.ItemTransactions.Any(e => e.Id == id);
        }
    }
}
