using System.ComponentModel.DataAnnotations;
using AskerTracker.Core.BaseModels;
using AskerTracker.Core.Types;

namespace AskerTracker.Core
{
    public class Training : EventModel
    {
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(TrainingType))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "TrainingTypeRequired")]
        [EnumDataType(typeof(TrainingType))]
        public TrainingType TrainingType { get; set; }
    }
}