using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asker.Data;
using Asker.Models;

namespace Asker.Pages.TestingEvents
{
    public class EditModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public EditModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TestingEvent TestingEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TestingEvent = await _context.TestingEvent
                .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

            if (TestingEvent == null)
            {
                return NotFound();
            }
           ViewData["LocationId"] = new SelectList(_context.EventLocation, "Id", "Location");
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

            _context.Attach(TestingEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestingEventExists(TestingEvent.Id))
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

        private bool TestingEventExists(Guid id)
        {
            return _context.TestingEvent.Any(e => e.Id == id);
        }
    }
}
