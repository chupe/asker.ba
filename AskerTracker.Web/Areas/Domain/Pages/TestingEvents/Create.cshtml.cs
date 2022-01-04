﻿using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Areas.Domain.Pages.TestingEvents;

public class CreateModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public CreateModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public TestingEvent TestingEvent { get; set; }

    public IActionResult OnGet()
    {
        ViewData["LocationId"] = new SelectList(_context.EventLocations, "Id", "Location");
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.TestingEvents.Add(TestingEvent);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}