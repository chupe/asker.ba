using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Pages.MembershipFees
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<MembershipFee> _repository;

        public DeleteModel(IRepository<MembershipFee> repository)
        {
            _repository = repository;
        }

        [BindProperty] public MembershipFee MembershipFee { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            MembershipFee = await _repository.Get<MembershipFee>(f => f.Id == id.Value, f => f.Member);

            if (MembershipFee == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null) return NotFound();

            MembershipFee = await _repository.Get<MembershipFee>(x => x.MemberId == id.Value, y => y.Member);

            if (MembershipFee != null)
            {
                _repository.Remove(MembershipFee);
                await _repository.SaveChangesAsync();
                TempData["Message"] = $"Deleted membership fee for {MembershipFee.Member.FullName} successfully!";
            }

            return RedirectToPage("./Index");
        }
    }
}