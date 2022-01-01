using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Pages.Members;

public class IndexModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public IndexModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [TempData] public string Message { get; set; }

    public IList<Member> Members { get; set; }

    [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

    public async Task OnGetAsync()
    {
        var members = _context.Members.Select(m => m);

        if (!string.IsNullOrEmpty(SearchString))
            members = members.Where(s =>
                s.FullName.Contains(SearchString, StringComparison.CurrentCultureIgnoreCase));

        Members = members.ToList();
    }
}