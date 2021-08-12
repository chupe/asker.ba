using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public DetailsModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Training Training { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Training = await _context.Training.FirstOrDefaultAsync(m => m.Id == id);

            if (Training == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
