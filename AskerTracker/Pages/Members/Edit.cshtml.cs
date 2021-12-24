using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Core;
using AskerTracker.Core.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AskerTracker.Data;

namespace AskerTracker.Pages.Members
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHtmlHelper _htmlHelper;

        public EditModel(ApplicationDbContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            _htmlHelper = htmlHelper;
        }

        [BindProperty]
        public Member Member { get; set; }
        public IEnumerable<SelectListItem> BloodType { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Member = await _context.Member.FirstOrDefaultAsync(m => m.Id == id);
            BloodType = _htmlHelper.GetEnumSelectList<BloodType>();

            if (Member == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(Member.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MemberExists(Guid id)
        {
            return _context.Member.Any(e => e.Id == id);
        }
    }
}
