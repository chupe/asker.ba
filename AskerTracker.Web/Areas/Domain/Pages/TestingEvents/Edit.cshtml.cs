﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.TestingEvents;

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

    public string ReturnUrl { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        TestingEvent = await _context.TestingEvents
            .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

        if (TestingEvent == null) return NotFound();
        
        ReturnUrl = Request.Headers["Referer"].ToString().ToRelativePath();

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