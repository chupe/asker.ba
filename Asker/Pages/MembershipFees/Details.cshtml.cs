using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asker.Data;
using Asker.Models;

namespace Asker.Pages.MembershipFees
{
    public class DetailsModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public DetailsModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MembershipFee MembershipFee { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembershipFee = await _context.MembershipFee
                .Include(m => m.Member).FirstOrDefaultAsync(m => m.Id == id);

            if (MembershipFee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
