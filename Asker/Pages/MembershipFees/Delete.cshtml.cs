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
    public class DeleteModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public DeleteModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MembershipFee MembershipFee { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembershipFee = await _context.MembershipFee.FirstOrDefaultAsync(m => m.Id == id);

            if (MembershipFee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembershipFee = await _context.MembershipFee.FindAsync(id);

            if (MembershipFee != null)
            {
                _context.MembershipFee.Remove(MembershipFee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
