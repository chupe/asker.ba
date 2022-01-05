﻿using System;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.Items;

public class DeleteModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Item Item { get; set; }

    public string ReturnUrl { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        Item = await _context.Items
            .Include(i => i.Lender)
            .Include(i => i.Owner).FirstOrDefaultAsync(m => m.Id == id);

        if (Item == null) return NotFound();
        
        ReturnUrl = Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id, string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (id == null) return NotFound();

        Item = await _context.Items.FindAsync(id);

        if (Item != null)
        {
            _context.Items.Remove(Item);
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Removed {Item.Name} successfully!";
        }

        return LocalRedirect(returnUrl);
    }
}