using System;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Pages.Items
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Item> _repository;

        public DetailsModel(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Item = await _repository.Get<Item>(x => x.Id == id.Value, x => x.Lender);
            var owner = (await _repository.Get<Item>(x => x.Id == id.Value, x => x.Owner)).Owner;

            Item.IncludeMore(i => i.Owner, owner);

            if (Item == null) return NotFound();
            return Page();
        }
    }
}