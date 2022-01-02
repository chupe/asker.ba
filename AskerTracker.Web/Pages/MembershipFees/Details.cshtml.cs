﻿using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees;

public class DetailsModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public DetailsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public MembershipFee MembershipFee { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        MembershipFee = await _context.MembershipFees
            .Include(m => m.Member).FirstOrDefaultAsync(m => m.Id == id);

        if (MembershipFee == null) return NotFound();
        
        ViewData["Referer"] = Request.Headers["Referer"].ToString();

        return Page();
    }
}