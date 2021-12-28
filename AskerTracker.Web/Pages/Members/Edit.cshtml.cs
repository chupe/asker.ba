using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Members
{
    public class EditModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;
        private readonly IHtmlHelper _htmlHelper;

        public EditModel(AskerTrackerDbContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            _htmlHelper = htmlHelper;
        }

        [BindProperty] public Member Member { get; set; }

        public IEnumerable<SelectListItem> BloodType => _htmlHelper.GetEnumSelectList<BloodType>();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Member = await _context.Member.FirstOrDefaultAsync(m => m.Id == id);

            if (Member == null) return NotFound();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(Member.Id))
                    return NotFound();
                throw;
            }

            TempData["Message"] = "Saved successfully!";
            return RedirectToPage("./Index");
        }

        private bool MemberExists(Guid id)
        {
            return _context.Member.Any(e => e.Id == id);
        }
    }
}