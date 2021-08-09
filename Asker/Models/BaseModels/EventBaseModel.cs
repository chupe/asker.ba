using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Asker.Resources.Localization;


namespace Asker.Models
{
    public partial class EventBaseModel : BaseModel
    {
        public EventBaseModel() : base() { }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(Location))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "LocationRequired")]
        [StringLength(15, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to15", MinimumLength = 3)]
        public TrainingLocation Location { get; set; }

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]

        [Display(ResourceType = typeof(UILocalization), Name = nameof(DateHeld))]

        [DataType(DataType.Date)]
        public DateTime DateHeld { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(ParticipantsList))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ParticipantsRequired")]
        public ICollection<Member> ParticipantsList { get; set; }
    }
}
