using System;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Pages.Items
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Item> _repository;

        public DeleteModel(IRepository<Item> repository)
        {
            _repository = repository;
        }

        [BindProperty] public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Item = await _repository.Get<Item>(x => x.Id == id.Value, x => x.Lender);
            var owner = (await _repository.Get<Item>(x => x.Id == id.Value, x => x.Owner)).Owner;

            Item.IncludeMore(i => i.Owner, owner);

            if (Item == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Item = await _repository.Get(id.Value);

            if (Item != null)
            {
                _repository.Remove(Item);
                await _repository.SaveChangesAsync();
                TempData["Message"] = $"Removed {Item.Name} successfully!";
            }

            return RedirectToPage("./Index");
        }
    }
}