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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TestingResult> TestingResult { get;set; }

        public async Task OnGetAsync()
        {
            TestingResult = await _context.TestingResult
                .Include(t => t.Event)
                .Include(t => t.Member).ToListAsync();
        }
    }
}
