using System.ComponentModel.DataAnnotations;
using AskerTracker.Core.BaseModels;
using AskerTracker.Core.Types;

namespace AskerTracker.Core
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
