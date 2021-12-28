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
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Member> _repository;

        public DetailsModel(IRepository<Member> repository)
        {
            _repository = repository;
        }

        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Member = await _repository.Get(id.Value);

            if (Member == null) return NotFound();
            
            return Page();
        }
    }
}