using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees;

public class EditModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public EditModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public MembershipFee MembershipFee { get; set; }

    public IEnumerable<SelectListItem> MembersSelectList =>
        Helper.GetSelectList<Member>(_context, m => m.FullName).Result;
    
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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid) return Page();

        _context.Attach(MembershipFee).State = EntityState.Modified;
        await _context.Entry(MembershipFee).Reference(m => m.Member).LoadAsync();

        try
        {
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Saved membership fee for {MembershipFee.Member.FullName} successfully!";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MembershipFeeExists(MembershipFee.Id))
                return NotFound();
            throw;
        }

        return LocalRedirect(returnUrl);
    }

    private bool MembershipFeeExists(Guid id)
    {
        return _context.MembershipFees.Any(e => e.Id == id);
    }
}