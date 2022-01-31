using System;
using System.Threading.Tasks;
using AskerTracker.Domain.Entities;
using AskerTracker.Persistence;
using AskerTracker.Web.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.Members;

public class DeleteModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Member Member { get; set; }

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id, string returnUrl = null)
    {
        if (id == null) return NotFound();

        Member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);

        if (Member == null) return NotFound();

        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ReturnUrl ??= Url.Content("~/Domain/Members/Index");

        Member = await _context.Members.FindAsync(Member.Id);

        if (Member != null)
        {
            _context.Members.Remove(Member);
            await _context.SaveChangesAsync();
            TempData["Message"] = $"{Member.FullName} deleted";
        }

        return LocalRedirect(ReturnUrl);
    }
}