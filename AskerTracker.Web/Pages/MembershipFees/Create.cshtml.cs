using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<MembershipFee> _repository;

        public CreateModel(IRepository<MembershipFee> repository)
        {
            _repository = repository;
        }

        [BindProperty] public MembershipFee MembershipFee { get; set; }

        public SelectList Members => Helper.GetSelectList(_repository).Result;

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from over-posting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                _repository.Add(MembershipFee);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }

            TempData["Message"] = $"Added fee for {MembershipFee.Member.FullName} successfully!";

            return RedirectToPage("./Index");
        }
    }
}