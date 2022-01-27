using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Web.Common.Extensions;
using AskerTracker.Web.Common;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Web.Areas.Domain.Pages.Trainings;

public class CreateModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;
    private readonly IHtmlHelper _htmlHelper;

    public CreateModel(AskerTrackerDbContext context, IHtmlHelper htmlHelper)
    {
        _context = context;
        _htmlHelper = htmlHelper;
    }

    [BindProperty] public Training Training { get; set; }

    public IEnumerable<SelectListItem> EventLocationSelectList => Helper.GetSelectList<EventLocation>(_context, l => l.Location).Result;

    public IEnumerable<SelectListItem> TrainingType => _htmlHelper.GetEnumSelectList<TrainingType>();
    
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

        _context.Trainings.Add(Training);
        await _context.SaveChangesAsync();
        TempData["Message"] = $"Added training held on {Training.DateHeld} successfully!";

        return LocalRedirect(returnUrl);
    }
}