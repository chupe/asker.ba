using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asker.Data;
using Asker.Models;

namespace Asker.Pages.ItemTransactions
{
    public class DetailsModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public DetailsModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ItemTransaction ItemTransaction { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemTransaction = await _context.ItemTransaction.FirstOrDefaultAsync(m => m.Id == id);

            if (ItemTransaction == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
