using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Asker.Resources.Localization;


namespace Asker.Models
{
    public class EventParticipation : EntityModel
    {
        public EventParticipation() : base() { }

        [ForeignKey("EventId")]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(EventId))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "EventRequired")]
        public Guid EventId { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(List))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ParticipantsRequired")]
        public IEnumerable<Member> List { get; set; }
    }
}
