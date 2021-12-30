using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Pages.MembershipFees
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<MembershipFee> _repository;

        public DetailsModel(IRepository<MembershipFee> repository)
        {
            _repository = repository;
        }

        public MembershipFee MembershipFee { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            MembershipFee = await _repository.Get<MembershipFee>(f => f.Id == id.Value, f => f.Member);

            if (MembershipFee == null) return NotFound();
            return Page();
        }
    }
}