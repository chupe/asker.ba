using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.Members;

public class IndexModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public IndexModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<Member> Members { get; set; }

    [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

    public async Task OnGetAsync()
    {
        var members = await _context.Members.Select(m => m).ToListAsync();

        if (!string.IsNullOrEmpty(SearchString))
            members = members.Where(s =>
                s.FullName.Contains(SearchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

        Members = members;
    }
}