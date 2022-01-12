using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Resources.Localization;

namespace AskerTracker.Domain;

public class EventLocation : EntityModel
{
    [Required]
    [StringLength(40, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to40",
        MinimumLength = 3)]
    [DataType(DataType.Text)]
    public string Location { get; set; }
}