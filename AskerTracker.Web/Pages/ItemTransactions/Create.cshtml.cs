﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;

namespace AskerTracker.Pages.ItemTransactions
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
        ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name");
        ViewData["LenderId"] = new SelectList(_context.Members, "Id", "FirstName");
        ViewData["OwnerId"] = new SelectList(_context.Members, "Id", "FirstName");
        ViewData["PreviousId"] = new SelectList(_context.ItemTransactions, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ItemTransaction ItemTransaction { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ItemTransactions.Add(ItemTransaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
