using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AskerTracker.Core.Resources.Localization;

namespace AskerTracker.Core.BaseModels
{
    public class EventModel : EntityModel
    {
        public EventModel()
        {
            Participants = new HashSet<Member>();
        }

        [ForeignKey("Location")] public Guid LocationId { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Location))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "LocationRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to50",
            MinimumLength = 3)]
        public EventLocation Location { get; set; }

        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(DateHeld))]
        [DataType(DataType.Date)]
        public DateTime DateHeld { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Participants))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ParticipantsRequired")]
        public ICollection<Member> Participants { get; set; }
    }
}