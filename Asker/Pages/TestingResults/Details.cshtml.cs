using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Data;
using AskerTracker.Models;

namespace AskerTracker.Pages.TestingResults
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public TestingResult TestingResult { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TestingResult = await _context.TestingResult
                .Include(t => t.Event)
                .Include(t => t.Member).FirstOrDefaultAsync(m => m.Id == id);

            if (TestingResult == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
