using System;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public DetailsModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Member = await _context.Member.FirstOrDefaultAsync(m => m.Id == id);

            if (Member == null) return NotFound();
            return Page();
        }
    }
}