using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asker.Data;
using Asker.Models;

namespace Asker.Pages.ItemTransactions
{
    public class CreateModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public CreateModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LenderId"] = new SelectList(_context.Member, "Id", "FirstName");
        ViewData["OwnerId"] = new SelectList(_context.Member, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public ItemTransaction ItemTransaction { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ItemTransaction.Add(ItemTransaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
