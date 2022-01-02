using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.MembershipFees;

public class CreateModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public CreateModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public MembershipFee MembershipFee { get; set; }

    public IEnumerable<SelectListItem> MembersSelectList => Helper.GetSelectList<Member>(_context, m => m.FullName).Result;

    public string ReturnUrl { get; set; }
    
    public IActionResult OnGet()
    {
        ReturnUrl = Request.Headers["Referer"].ToString().ToRelativePath();
        
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync(string returnUrl)
    {
        returnUrl ??= Url.Content("~/");
        
        if (!ModelState.IsValid) return Page();

        _context.MembershipFees.Add(MembershipFee);
        await _context.SaveChangesAsync();
        TempData["Message"] = $"Added fee for {MembershipFee.Member.FullName} successfully!";

        return LocalRedirect(returnUrl);
    }
}