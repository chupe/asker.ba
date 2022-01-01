﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.Items;

public class CreateModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public CreateModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Item Item { get; set; }
    
    public IEnumerable<SelectListItem> MembersSelectList =>
        Helper.GetSelectList<Member>(_context, m => m.FullName).Result.AppendTeamPropertyItem();
    
    public IActionResult OnGet()
    {
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Items.Add(Item);
        await _context.SaveChangesAsync();
        TempData["Message"] = $"Created new item {Item.Name} successfully!";

        return RedirectToPage("./Index");
    }
}