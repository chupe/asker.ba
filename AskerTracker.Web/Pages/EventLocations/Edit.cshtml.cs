using System;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.EventLocations
{
    public class EditModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public EditModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty] public EventLocation EventLocation { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            EventLocation = await _context.EventLocation.FirstOrDefaultAsync(m => m.Id == id);

            if (EventLocation == null) return NotFound();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(EventLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventLocationExists(EventLocation.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool EventLocationExists(Guid id)
        {
            return _context.EventLocation.Any(e => e.Id == id);
        }
    }
}