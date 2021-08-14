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

namespace Asker.Pages.Members
{
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

        //public SelectList FullNames { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string MemberFullName { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> nameQuery = from m in _context.Member
                                            orderby m.FullName
                                            select m.FullName;

            var members = from m in _context.Member
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                members = members.Where(s => s.FullName.Contains(SearchString));
            }

            //if (!string.IsNullOrEmpty(MemberFullName))
            //{
            //    members = members.Where(x => x.FullName == MemberFullName);
            //}
            //FullNames = new SelectList(await nameQuery.Distinct().ToListAsync());
            Member = await members.ToListAsync();
        }
    }
}
