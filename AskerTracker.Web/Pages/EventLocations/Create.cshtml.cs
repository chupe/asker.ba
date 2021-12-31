﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;

namespace AskerTracker.Pages.EventLocations
{
    public class CreateModel : PageModel
    {
        private readonly AskerTracker.Infrastructure.AskerTrackerDbContext _context;

        public CreateModel(AskerTracker.Infrastructure.AskerTrackerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EventLocation EventLocation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EventLocations.Add(EventLocation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
