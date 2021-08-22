using System.ComponentModel.DataAnnotations;
using AskerTracker.Resources.Localization;
using AskerTracker.Types;

namespace AskerTracker.Models
{
    public class Training : EventModel
    {
        public Training() : base() { }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(TrainingType))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "TrainingTypeRequired")]
        [EnumDataType(typeof(TrainingType))]
        public TrainingType TrainingType { get; set; }
    }
}
