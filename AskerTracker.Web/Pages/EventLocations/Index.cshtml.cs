﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;

namespace AskerTracker.Pages.EventLocations
{
    public class IndexModel : PageModel
    {
        private readonly AskerTracker.Infrastructure.AskerTrackerDbContext _context;

        public IndexModel(AskerTracker.Infrastructure.AskerTrackerDbContext context)
        {
            _context = context;
        }

        public IList<EventLocation> EventLocation { get;set; }

        public async Task OnGetAsync()
        {
            EventLocation = await _context.EventLocations.ToListAsync();
        }
    }
}
