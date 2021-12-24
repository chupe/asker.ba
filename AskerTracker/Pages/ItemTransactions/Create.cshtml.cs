using System.Threading.Tasks;
using AskerTracker.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AskerTracker.Data;

namespace AskerTracker.Pages.ItemTransactions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
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
