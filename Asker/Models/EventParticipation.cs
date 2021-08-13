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

        [Display(ResourceType = typeof(UILocalization), Name = nameof(List))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ParticipantsRequired")]
        public HashSet<Guid> List { get; set; }
    }
}
