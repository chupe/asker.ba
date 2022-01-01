using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.Members;

public class CreateModel : PageModel
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

    public IActionResult OnGet()
    {
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Members.Add(Member);
        await _context.SaveChangesAsync();
        TempData["Message"] = $"Added {Member.FullName} successfully!";

        return RedirectToPage("./Index");
    }
}