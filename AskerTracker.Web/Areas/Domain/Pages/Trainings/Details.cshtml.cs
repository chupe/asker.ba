﻿using System;
using System.Threading.Tasks;
using AskerTracker.Web.Common.Extensions;
using AskerTracker.Domain.Entities;
using AskerTracker.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.Trainings;

public class DetailsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DetailsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public Training Training { get; set; }

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }
    
    public async Task<IActionResult> OnGetAsync(Guid? id, string returnUrl = null)
    {
        if (id == null) return NotFound();

        Training = await _context.Trainings
            .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

        if (Training == null) return NotFound();
        
        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }
}