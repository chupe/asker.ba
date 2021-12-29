using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Common
{
    public static class Helper
    {
        public static async Task<IEnumerable<SelectListItem>> GetMemberSelectList(IRepository<Member> repository,
            string dataValueField = "Id", string dataTextField = "FullName", bool selectedValue = false, bool additionalItem = false)
        {
            var list = (await repository.All()).ToList();

            var membersList = list.OrderBy(m => m.FullName).GroupBy(x => x.FullName)
                .Select(y => y.First()).ToList();

            return new SelectList(membersList, dataValueField, dataTextField, selectedValue);
        }

        public static IEnumerable<SelectListItem> AppendItem(this IEnumerable<SelectListItem> list, SelectListItem item)
        {
            return list.Append(item);
        }   
    }
}