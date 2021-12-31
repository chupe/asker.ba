using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AskerTracker.Domain.Resources.Localization;

namespace AskerTracker.Domain.BaseModels
{
    public class EventModel : EntityModel
    {
        [ForeignKey(nameof(Location))] public Guid LocationId { get; set; }

        [Required]
        [StringLength(50, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to50",
            MinimumLength = 3)]
        public EventLocation Location { get; set; }

        [Required] [DataType(DataType.Date)] public DateTime DateHeld { get; set; }

        [Required] public HashSet<Member> Participants { get; set; } = new();
    }
}