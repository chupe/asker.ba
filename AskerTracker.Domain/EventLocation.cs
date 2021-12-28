using System.ComponentModel.DataAnnotations;
using AskerTracker.Core.BaseModels;
using AskerTracker.Core.Resources.Localization;

namespace AskerTracker.Core
{
    public class EventLocation : EntityModel
    {
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Location))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "LocationRequired")]
        [StringLength(40, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to40",
            MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Location { get; set; }
    }
}