using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.Resources.Localization;

namespace AskerTracker.Domain.Types;

public enum BloodType
{
    [Display(ResourceType = typeof(UILocalization), Name = "OPositive")]
    OPositive,

    [Display(ResourceType = typeof(UILocalization), Name = "APositive")]
    APositive,

    [Display(ResourceType = typeof(UILocalization), Name = "BPositive")]
    BPositive,

    [Display(ResourceType = typeof(UILocalization), Name = "ABPositive")]
    AbPositive,

    [Display(ResourceType = typeof(UILocalization), Name = "ABNegative")]
    AbNegative,

    [Display(ResourceType = typeof(UILocalization), Name = "ANegative")]
    ANegative,

    [Display(ResourceType = typeof(UILocalization), Name = "BNegative")]
    BNegative,

    [Display(ResourceType = typeof(UILocalization), Name = "ONegative")]
    ONegative
}