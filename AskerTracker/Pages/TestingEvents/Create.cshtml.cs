using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.TestingEvents
{
    public class CreateModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public CreateModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty] public TestingEvent TestingEvent { get; set; }

        public IActionResult OnGet()
        {
            ViewData["LocationId"] = new SelectList(_context.EventLocation, "Id", "Location");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.TestingEvent.Add(TestingEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}