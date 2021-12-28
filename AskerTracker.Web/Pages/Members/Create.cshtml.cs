using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly IRepository<Member> _repository;

        public CreateModel(IRepository<Member> repository, IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
            _repository = repository;
        }

        [BindProperty] public Member Member { get; set; }
        
        public IEnumerable<SelectListItem> BloodType => _htmlHelper.GetEnumSelectList<BloodType>();

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Add(Member);
            await _repository.SaveChangesAsync();

            TempData["Message"] = $"Added {Member.FullName} successfully!";
            return RedirectToPage("./Index");
        }
    }
}