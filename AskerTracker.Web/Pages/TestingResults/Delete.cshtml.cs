﻿using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.TestingResults
{
    public class DeleteModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public DeleteModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty] public TestingResult TestingResult { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            TestingResult = await _context.TestingResult
                .Include(t => t.Event)
                .Include(t => t.Member).FirstOrDefaultAsync(m => m.Id == id);

            if (TestingResult == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null) return NotFound();

            TestingResult = await _context.TestingResult.FindAsync(id);

            if (TestingResult != null)
            {
                _context.TestingResult.Remove(TestingResult);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}