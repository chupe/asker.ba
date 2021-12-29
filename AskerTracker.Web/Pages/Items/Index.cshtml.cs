using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly AskerTrackerDbContext _context;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Item> _repository;

        public IndexModel(AskerTrackerDbContext context, IRepository<Member> memberRepository, IRepository<Item> repository)
        {
            _context = context;
            _memberRepository = memberRepository;
            _repository = repository;
        }

        public IList<Item> Item { get; set; }

        public async Task OnGetAsync()
        {
            Item = (await _repository.All<Item>(x => x.Lender)).ToList();
            var owners = (await _repository.All<Item>(x => x.Owner)).Select(y => y.Owner).ToList();

            for (var i = 0; i < Item.Count; i++)
            {
                Item[i].Owner = owners[i];
            }
        }
    }
}