using System;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees
{
    public class EditModel : PageModel
    {
        private readonly IRepository<MembershipFee> _repository;
        private readonly IRepository<Member> _memberRepository;

        public EditModel(IRepository<MembershipFee> repository, IRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        [BindProperty] public MembershipFee MembershipFee { get; set; }

        public SelectList Members => Helper.GetMemberSelectList(_memberRepository).Result;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            MembershipFee = await _repository.Get<MembershipFee>(x => x.Id == id.Value, m => m.Member);

            if (MembershipFee == null) return NotFound();
            
            return Page();
        }

        // To protect from over-posting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Update(MembershipFee);

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MembershipFeeExists(MembershipFee.Id))
                    return NotFound();
                throw;
            }

            MembershipFee = await _repository.Get<MembershipFee>(x => x.Id == MembershipFee.Id, m => m.Member);

            TempData["Message"] = $"Saved membership fee for {MembershipFee.Member.FullName} successfully!";
            return RedirectToPage("./Index");
        }

        private async Task<bool> MembershipFeeExists(Guid id)
        {
            return await _repository.Get(id) != null;
        }
    }
}