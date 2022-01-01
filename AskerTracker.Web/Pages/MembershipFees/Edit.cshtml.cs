using System;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees;

public class EditModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public EditModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public MembershipFee MembershipFee { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        MembershipFee = await _context.MembershipFees
            .Include(m => m.Member).FirstOrDefaultAsync(m => m.Id == id);

        if (MembershipFee == null) return NotFound();
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "FirstName");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(MembershipFee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MembershipFeeExists(MembershipFee.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool MembershipFeeExists(Guid id)
    {
        return _context.MembershipFees.Any(e => e.Id == id);
    }
}