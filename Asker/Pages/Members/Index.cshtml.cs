using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asker.Data;
using Asker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Asker.Pages.Members
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Asker.Data.ApplicationDbContext _context;

        public IndexModel(Asker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> nameQuery = from m in _context.Member
                                            orderby m.FullName
                                            select m.FullName;

            var members = from m in _context.Member
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                members = members.Where(s => s.FullName.Contains(SearchString));
            }

            Member = await members.ToListAsync();
        }
    }
}
