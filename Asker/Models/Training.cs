using System.ComponentModel.DataAnnotations;
using Asker.Resources.Localization;
using Asker.Types;

namespace Asker.Models
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
