using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Item> _repository;

        public EditModel(IRepository<Item> repository,
            IRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        [BindProperty] public Item Item { get; set; }

        public IEnumerable<SelectListItem> MembersSelectList =>
            Helper.GetMemberSelectList(_memberRepository).Result.AppendTeamPropertyItem();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Item = await _repository.Get<Item>(x => x.Id == id.Value, x => x.Lender);
            var owner = (await _repository.Get<Item>(x => x.Id == id.Value, x => x.Owner)).Owner;

            Item.IncludeMore(i => i.Owner, owner);

            if (Item == null) return NotFound();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Update(Item);

            try
            {
                await _repository.SaveChangesAsync();
                TempData["Message"] = $"Saved item {Item.Name} successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Item.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool ItemExists(Guid id)
        {
            return _repository.Get(id) != null;
        }
    }
}