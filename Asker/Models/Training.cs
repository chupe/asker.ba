using System.ComponentModel.DataAnnotations;
using Asker.Resources;

namespace Asker.Models
{
    public class Training : EventBaseModel
    {
        public Training() : base() { }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(TrainingType))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "TrainingTypeRequired")]
        [EnumDataType(typeof(TrainingType))]
        public TrainingType TrainingType { get; set; }
    }
}
