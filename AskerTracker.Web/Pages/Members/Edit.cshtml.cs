using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Members
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Member> _repository;
        private readonly IHtmlHelper _htmlHelper;

        public EditModel(IRepository<Member> repository, IHtmlHelper htmlHelper)
        {
            _repository = repository;
            _htmlHelper = htmlHelper;
        }

        [BindProperty] public Member Member { get; set; }

        public IEnumerable<SelectListItem> BloodType => _htmlHelper.GetEnumSelectList<BloodType>();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Member = await _repository.Get(id.Value);

            if (Member == null) return NotFound();
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Update(Member);

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MemberExists(Member.Id))
                    return NotFound();
                throw;
            }

            TempData["Message"] = $"Saved {Member.FullName} successfully!";
            return RedirectToPage("./Index");
        }

        private async Task<bool> MemberExists(Guid id)
        {
            var member = await _repository.Find(e => e.Id == id);
            return member != null;
        }
    }
}