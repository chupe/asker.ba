using System;
using System.Threading.Tasks;
using AskerTracker.Web.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Web.Areas.Domain.Pages.Trainings;

public class DeleteModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public DeleteModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Training Training { get; set; }

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }
    
    public async Task<IActionResult> OnGetAsync(Guid? id, string returnUrl = null)
    {
        if (id == null) return NotFound();

        Training = await _context.Trainings
            .Include(t => t.Location).FirstOrDefaultAsync(m => m.Id == id);

        if (Training == null) return NotFound();
        
        ReturnUrl ??= Request.Headers["Referer"].ToString().ToRelativePath();

        return Page();
    }


    public async Task<IActionResult> OnPostAsync(Guid? id, string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (id == null) return NotFound();

        Training = await _context.Trainings.FindAsync(id);

        if (Training != null)
        {
            _context.Trainings.Remove(Training);
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Removed training held on {Training.DateHeld} successfully!";
        }

        return LocalRedirect(returnUrl);
    }
}