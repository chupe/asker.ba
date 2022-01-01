using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Items;

public class EditModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public EditModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Item Item { get; set; }

    public IEnumerable<SelectListItem> MembersSelectList =>
        Helper.GetSelectList<Member>(_context, m => m.FullName).Result.AppendTeamPropertyItem();
    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        Item = await _context.Items
            .Include(i => i.Lender)
            .Include(i => i.Owner).FirstOrDefaultAsync(m => m.Id == id);

        if (Item == null) return NotFound();

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Item).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Saved item {Item.Name} successfully!";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemExists(Item.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ItemExists(Guid id)
    {
        return _context.Items.Any(e => e.Id == id);
    }
}