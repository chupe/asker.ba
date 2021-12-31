﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;

namespace AskerTracker.Pages.MembershipFees
{
    public class DetailsModel : PageModel
    {
        private readonly AskerTracker.Infrastructure.AskerTrackerDbContext _context;

        public DetailsModel(AskerTracker.Infrastructure.AskerTrackerDbContext context)
        {
            _context = context;
        }

        public MembershipFee MembershipFee { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembershipFee = await _context.MembershipFees
                .Include(m => m.Member).FirstOrDefaultAsync(m => m.Id == id);

            if (MembershipFee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
