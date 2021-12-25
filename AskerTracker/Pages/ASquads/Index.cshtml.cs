﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.ASquads
{
    public class IndexModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public IndexModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        public IList<ASquad> ASquad { get; set; }

        public async Task OnGetAsync()
        {
            ASquad = await _context.ASquad.ToListAsync();
        }
    }
}