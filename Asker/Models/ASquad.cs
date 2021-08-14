using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Asker.Resources.Localization;


namespace Asker.Models
{
    public class ASquad : EntityModel
    {
        public ASquad() : base() { }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Member))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "MemberRequired")]
        public ICollection<Member> Members { get; set; }
    }
}
