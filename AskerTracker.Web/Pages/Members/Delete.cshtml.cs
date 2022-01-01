using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Members;

public class DeleteModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Member Member { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null) return NotFound();

        Member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);

        if (Member == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null) return NotFound();

        Member = await _context.Members.FindAsync(id);

        if (Member != null)
        {
            _context.Members.Remove(Member);
            await _context.SaveChangesAsync();
            TempData["Message"] = $"{Member.FullName} deleted";
        }

        return RedirectToPage("./Index");
    }
}