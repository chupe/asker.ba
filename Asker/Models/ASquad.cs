using System;
using System.ComponentModel.DataAnnotations;
using Asker.Resources.Localization;


namespace Asker.Models
{
    public class ASquad : EntityModel
    {
        public ASquad() : base() { }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(Member))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "MemberRequired")]
        public Member Member { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(Testing))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "TestingRequired")]
        public TestingEvent Testing { get; set; }
    }
}
