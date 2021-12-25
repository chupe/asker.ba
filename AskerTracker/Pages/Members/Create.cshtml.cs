using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public CreateModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty] public Member Member { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}