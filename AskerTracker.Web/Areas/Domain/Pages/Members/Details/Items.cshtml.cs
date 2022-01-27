using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.Members.Details;

public class ItemsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public ItemsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<Item> Item { get; set; }
    
    [BindProperty(SupportsGet = true)] public Guid? MemberFilter { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (MemberFilter == null) return NotFound();

        var memberExists = await _context.Members.AnyAsync(m => m.Id == MemberFilter);

        if (!memberExists) return NotFound();
        
        Item = await _context.Items
            .Where(i => i.LenderId == MemberFilter || i.OwnerId == MemberFilter)
            .Include(i => i.Lender)
            .Include(i => i.Owner)
            .ToListAsync();

        return Page();
    }
}