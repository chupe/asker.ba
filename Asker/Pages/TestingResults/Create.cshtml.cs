using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AskerTracker.Data;
using AskerTracker.Models;

namespace AskerTracker.Pages.TestingResults
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
        ViewData["EventId"] = new SelectList(_context.TestingEvent, "Id", "Id");
        ViewData["MemberId"] = new SelectList(_context.Member, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public TestingResult TestingResult { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TestingResult.Add(TestingResult);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
