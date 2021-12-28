using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Types;

namespace AskerTracker.Domain
{
    public class Training : EventModel
    {
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(TrainingType))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "TrainingTypeRequired")]
        [EnumDataType(typeof(TrainingType))]
        public TrainingType TrainingType { get; set; }
    }
}