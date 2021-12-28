using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.BaseModels;

namespace AskerTracker.Domain
{
    public class ASquad : EntityModel
    {
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Member))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "MemberRequired")]
        public ICollection<Member> Members { get; set; }
    }
}