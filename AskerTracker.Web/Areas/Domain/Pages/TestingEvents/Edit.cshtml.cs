using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Web.Common.Extensions;
using AskerTracker.Web.Common;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.TestingEvents;

public class EditModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;
    private readonly IHtmlHelper _htmlHelper;

    public EditModel(AskerTrackerDbContext context, IHtmlHelper htmlHelper)
    {
        _context = context;
        _htmlHelper = htmlHelper;
    }

    [BindProperty] public TestingEvent TestingEvent { get; set; }

    public IEnumerable<SelectListItem> EventLocationSelectList => Helper.GetSelectList<EventLocation>(_context, l => l.Location).Result;

    public IEnumerable<SelectListItem> TrainingType => _htmlHelper.GetEnumSelectList<TrainingType>();

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id, string returnUrl = null)
    {
        if (id == null) return NotFound();

        TestingEvent = await _context.TestingEvents
            .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

        if (TestingEvent == null) return NotFound();
        
        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync(string returnUrl)
    {
        returnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid) return Page();

        _context.Attach(TestingEvent).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TestingEventExists(TestingEvent.Id))
                return NotFound();
            throw;
        }

        TempData["Message"] = $"Saved testing held on {TestingEvent.DateHeld} successfully!";

        return LocalRedirect(returnUrl);
    }

    private bool TestingEventExists(Guid id)
    {
        return _context.TestingEvents.Any(e => e.Id == id);
    }
}