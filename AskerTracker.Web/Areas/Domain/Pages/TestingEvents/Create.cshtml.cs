using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Areas.Domain.Pages.TestingEvents;

public class CreateModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;
    private readonly IHtmlHelper _htmlHelper;

    public CreateModel(AskerTrackerDbContext context, IHtmlHelper htmlHelper)
    {
        _context = context;
        _htmlHelper = htmlHelper;
    }

    [BindProperty] public TestingEvent TestingEvent { get; set; }
    
    public IEnumerable<SelectListItem> EventLocationSelectList => Helper.GetSelectList<EventLocation>(_context, l => l.Location).Result;

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }

    public IActionResult OnGet()
    {
        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync(string returnUrl)
    {
        returnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid) return Page();

        _context.TestingEvents.Add(TestingEvent);
        await _context.SaveChangesAsync();
        TempData["Message"] = $"Created testing held on {TestingEvent.DateHeld} successfully!";

        return LocalRedirect(returnUrl);
    }
}