using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.MembershipFees
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public MembershipFee MembershipFee { get; set; }

        public IActionResult OnGet()
        {
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var member = await _context.Member.FindAsync(MembershipFee.MemberId);
            MembershipFee.Member = member;

            if (!ModelState.IsValid) return Page();

            _context.MembershipFee.Add(MembershipFee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}