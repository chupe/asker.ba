﻿using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;

        public CreateModel(AskerTrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty] public Item Item { get; set; }

        public IActionResult OnGet()
        {
            ViewData["LenderId"] = new SelectList(_context.Member, "Id", "FirstName");
            ViewData["OwnerId"] = new SelectList(_context.Member, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Item.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}