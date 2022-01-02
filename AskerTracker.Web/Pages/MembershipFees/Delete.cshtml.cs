using System;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees;

public class DeleteModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public MembershipFee MembershipFee { get; set; }

    public string ReturnUrl { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        MembershipFee = await _context.MembershipFees
            .Include(m => m.Member).FirstOrDefaultAsync(m => m.Id == id);

        if (MembershipFee == null) return NotFound();
        
        ReturnUrl = Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id, string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (id == null) return NotFound();

        MembershipFee = await _context.MembershipFees.FindAsync(id);

        if (MembershipFee != null)
        {
            await _context.Attach(MembershipFee).Reference(f => f.Member).LoadAsync();

            _context.MembershipFees.Remove(MembershipFee);
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Deleted membership fee for {MembershipFee.Member.FullName} of {MembershipFee.Amount} successfully!";
        }

        return LocalRedirect(returnUrl);
    }
}