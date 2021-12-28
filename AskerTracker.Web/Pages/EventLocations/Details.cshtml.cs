﻿using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.EventLocations
{
    public class DetailsModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public DetailsModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        public EventLocation EventLocation { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            EventLocation = await _context.EventLocation.FirstOrDefaultAsync(m => m.Id == id);

            if (EventLocation == null) return NotFound();
            return Page();
        }
    }
}