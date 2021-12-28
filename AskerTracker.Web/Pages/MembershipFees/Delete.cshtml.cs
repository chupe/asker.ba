using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees
{
    public class DeleteModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public DeleteModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty] public MembershipFee MembershipFee { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            MembershipFee = await _context.MembershipFee
                .Include(m => m.Member).FirstOrDefaultAsync(m => m.Id == id);

            if (MembershipFee == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null) return NotFound();

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