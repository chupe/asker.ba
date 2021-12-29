using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Common
{
    public static class Helper
    {
        // private readonly IRepository<Member> _repository;
        //
        // public Helper(IRepository<Member> repository)
        // {
        //     _repository = repository;
        // }

        public static async Task<SelectList> GetMemberSelectList(IRepository<Member> repository)
        {
            var list = (await repository.All()).ToList();

            var membersList = list.OrderBy(m => m.FullName).GroupBy(x => x.FullName)
                .Select(y => y.First()).ToList();

            return new SelectList(membersList, "Id", "FullName");
        }
    }
}