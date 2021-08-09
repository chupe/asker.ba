using System;
using System.ComponentModel.DataAnnotations;

using Asker.Resources.Localization;


namespace Asker.Models
{
    public class ASquad : BaseModel
    {
        public ASquad() : base() { }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(MemberId))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "MemberRequired")]
        public Guid MemberId { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(TestingId))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "TestingRequired")]
        public Guid TestingId { get; set; }
    }
}
