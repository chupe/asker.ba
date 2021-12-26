using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public EditModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty] public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Item = await _context.Item
                .Include(i => i.Lender)
                .Include(i => i.Owner).FirstOrDefaultAsync(m => m.Id == id);

            if (Item == null) return NotFound();

            ViewData["LenderId"] = new SelectList(_context.Member, "Id", "FirstName")
                .Append(new SelectListItem("Team property", "", true));

            ViewData["OwnerId"] = new SelectList(_context.Member, "Id", "FirstName")
                .Append(new SelectListItem("Team property", "", true));

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["LenderId"] = new SelectList(_context.Member, "Id", "FirstName")
                .Append(new SelectListItem("Team property", "", true));

            ViewData["OwnerId"] = new SelectList(_context.Member, "Id", "FirstName")
                .Append(new SelectListItem("Team property", "", true));
         
            if (!ModelState.IsValid) return Page();

            _context.Attach(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Item.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool ItemExists(Guid id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
    }
}