using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asker.Data;
using Asker.Models;

namespace Asker.Pages.ASquads
{
    public class IndexModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public IndexModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ASquad> ASquad { get;set; }

        public async Task OnGetAsync()
        {
            ASquad = await _context.ASquad.ToListAsync();
        }
    }
}
