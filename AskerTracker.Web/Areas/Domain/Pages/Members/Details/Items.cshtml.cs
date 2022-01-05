using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Areas.Domain.Pages.Members.Details;

public class ItemsModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public ItemsModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    public IList<Item> Item { get; set; }
    
    [BindProperty(SupportsGet = true)] public Guid MemberFilter { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? memberFilter)
    {
        if (memberFilter == null) return NotFound();

        var memberExists = await _context.Members.AnyAsync(m => m.Id == memberFilter);

        if (!memberExists) return NotFound();
        
        Item = await _context.Items
            .Where(i => i.LenderId == memberFilter || i.OwnerId == memberFilter)
            .Include(i => i.Lender)
            .Include(i => i.Owner)
            .ToListAsync();

        return Page();
    }
}