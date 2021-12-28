using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.TestingResults
{
    public class CreateModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public CreateModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty] public TestingResult TestingResult { get; set; }

        public IActionResult OnGet()
        {
            ViewData["EventId"] = new SelectList(_context.TestingEvent, "Id", "Id");
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.TestingResult.Add(TestingResult);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}