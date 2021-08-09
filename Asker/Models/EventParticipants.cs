using System;
using System.ComponentModel.DataAnnotations;

using Asker.Resources.Localization;


namespace Asker.Models
{
    public class EventParticipants : BaseModel
    {
        public EventParticipants() : base() { }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(EventId))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "EventRequired")]
        public Guid EventId { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(ParticipantId))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ParticipantsRequired")]
        public Guid ParticipantId { get; set; }
    }
}
