﻿using System;
using System.Threading.Tasks;
using Asker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Asker.Pages.Items
{
    public class DetailsModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public DetailsModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Item.FirstOrDefaultAsync(m => m.Id == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
