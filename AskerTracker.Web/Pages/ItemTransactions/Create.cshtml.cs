using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.ItemTransactions;

public class CreateModel : PageModel
{
    private readonly AskerTrackerDbContext _context;

    public CreateModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public ItemTransaction ItemTransaction { get; set; }

    public IActionResult OnGet()
    {
        ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name");
        ViewData["LenderId"] = new SelectList(_context.Members, "Id", "FirstName");
        ViewData["OwnerId"] = new SelectList(_context.Members, "Id", "FirstName");
        ViewData["PreviousId"] = new SelectList(_context.ItemTransactions, "Id", "Id");
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.ItemTransactions.Add(ItemTransaction);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}