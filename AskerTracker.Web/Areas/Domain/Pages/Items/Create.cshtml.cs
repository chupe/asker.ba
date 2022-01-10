using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Areas.Domain.Pages.Items;

public class CreateModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public CreateModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Item Item { get; set; }
    
    public IEnumerable<SelectListItem> MembersSelectList =>
        Helper.GetSelectList<Member>(_context, m => m.FullName).Result.AppendTeamPropertyItem();
    
    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }

    public IActionResult OnGet()
    {
        ReturnUrl = Request.Headers["Referer"].ToString();

        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync(string returnUrl)
    {
        returnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid) return Page();

        _context.Items.Add(Item);
        await _context.SaveChangesAsync();
        TempData["Message"] = $"Created new item {Item.Name} successfully!";

        return LocalRedirect(returnUrl);
    }
}