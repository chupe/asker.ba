﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Data;
using AskerTracker.Models;

namespace AskerTracker.Pages.TestingEvents
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TestingEvent> TestingEvent { get;set; }

        public async Task OnGetAsync()
        {
            TestingEvent = await _context.TestingEvent
                .Include(t => t.Location).ToListAsync();
        }
    }
}
