using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.Members;

public class EditModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;
    private readonly IHtmlHelper _htmlHelper;

    public EditModel(AskerTrackerDbContext context, IHtmlHelper htmlHelper)
    {
        _context = context;
        _htmlHelper = htmlHelper;
    }

    [BindProperty] public Member Member { get; set; }

    public IEnumerable<SelectListItem> BloodType => _htmlHelper.GetEnumSelectList<BloodType>();

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }
    
    public async Task<IActionResult> OnGetAsync(Guid? id, string returnUrl = null)
    {
        if (id == null) return NotFound();

        Member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);

        if (Member == null) return NotFound();
        
        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid) return Page();

        _context.Attach(Member).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Saved {Member.FullName} successfully!";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MemberExists(Member.Id))
                return NotFound();
            throw;
        }

        return LocalRedirect(returnUrl);
    }

    private bool MemberExists(Guid id)
    {
        return _context.Members.Any(e => e.Id == id);
    }
}