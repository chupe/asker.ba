using System;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Members
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Member> _repository;

        public DeleteModel(IRepository<Member> repository)
        {
            _repository = repository;
        }

        [BindProperty] public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Member = await _repository.Get(id.Value);

            if (Member == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Member = await _repository.Get(id.Value);

            if (Member != null)
            {
                _repository.Remove(Member);
                await _repository.SaveChangesAsync();
                TempData["Message"] = $"{Member.FullName} deleted";
            }

            return RedirectToPage("./Index");
        }
    }
}