using System.ComponentModel.DataAnnotations;
using AskerTracker.Resources.Localization;


namespace AskerTracker.Models
{
    public class EventLocation : EntityModel
    {
        public EventLocation() : base() { }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Location))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "LocationRequired")]
        [StringLength(40, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to40", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Location { get; set; }
    }
}
