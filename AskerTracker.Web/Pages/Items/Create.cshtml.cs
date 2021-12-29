using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Item> _repository;
        private readonly IRepository<Member> _memberRepository;

        public CreateModel(IRepository<Item> repository,
            IRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        public IEnumerable<SelectListItem> MembersSelectList =>
            Helper.GetMemberSelectList(_memberRepository).Result.AppendTeamPropertyItem();

        [BindProperty] public Item Item { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Add(Item);
            await _repository.SaveChangesAsync();

            TempData["Message"] = $"Added item {Item.Name} successfully!";

            return RedirectToPage("./Index");
        }
    }
}