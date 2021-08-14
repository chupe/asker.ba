using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Asker.Resources.Localization;


namespace Asker.Models
{
    public class ASquad : EntityModel
    {
        public ASquad() : base() { }

        [ForeignKey("Member")]
        public Guid MemberId { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Member))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "MemberRequired")]
        public Member Member { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Testing))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "TestingRequired")]
        public TestingEvent Testing { get; set; }
    }
}
