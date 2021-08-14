﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asker.Data;
using Asker.Models;

namespace Asker.Pages.Trainings
{
    public class DeleteModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public DeleteModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Training Training { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Training = await _context.Training
                .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

            if (Training == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Training = await _context.Training.FindAsync(id);

            if (Training != null)
            {
                _context.Training.Remove(Training);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
