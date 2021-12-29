using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Item> _repository;

        public IndexModel(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public IList<Item> Item { get; set; }
        
        [TempData] public string Message { get; set; }

        public async Task OnGetAsync()
        {
            Item = (await _repository.All<Item>(x => x.Lender)).ToList();
            var owners = (await _repository.All<Item>(x => x.Owner)).Select(y => y.Owner).ToList();

            Item.IncludeMore(x => x.Owner, owners);
        }
    }
}