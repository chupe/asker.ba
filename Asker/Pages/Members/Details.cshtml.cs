using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asker.Data;
using Asker.Models;

namespace Asker.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public DetailsModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Member = await _context.Member.FirstOrDefaultAsync(m => m.Id == id);

            if (Member == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
