using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure;
using AskerTracker.Web.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Web.Areas.Domain.Pages.Members;

public class CreateModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;
    private readonly IHtmlHelper _htmlHelper;

    public CreateModel(AskerTrackerDbContext context, IHtmlHelper htmlHelper)
    {
        _context = context;
        _htmlHelper = htmlHelper;
    }

    [BindProperty] public Member Member { get; set; }

    public IEnumerable<SelectListItem> BloodType => _htmlHelper.GetEnumSelectList<BloodType>();

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }

    public IActionResult OnGet()
    {
        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        ReturnUrl ??= Url.Content("Index");

        if (!ModelState.IsValid) return Page();

        _context.Members.Add(Member);
        await _context.SaveChangesAsync();
        TempData["Message"] = $"Added {Member.FullName} successfully!";

        return RedirectToPage("./Index");
    }
}