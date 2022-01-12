using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using AskerTracker.Web.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.MembershipFees;

public class DeleteModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public MembershipFee MembershipFee { get; set; }

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id, string returnUrl = null)
    {
        if (id == null) return NotFound();

        MembershipFee = await _context.MembershipFees
            .Include(m => m.Member).FirstOrDefaultAsync(m => m.Id == id);

        if (MembershipFee == null) return NotFound();
        
        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

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