using System.ComponentModel.DataAnnotations;

namespace Asker.Resources
{
    public enum BloodType
    {

        [Display(ResourceType = typeof(UILocalization), Name = "OPositive")]

        OPositive,

        [Display(ResourceType = typeof(UILocalization), Name = "APositive")]

        APositive,

        [Display(ResourceType = typeof(UILocalization), Name = "BPositive")]

        BPositive,

        [Display(ResourceType = typeof(UILocalization), Name = "ABPositive")]

        ABPositive,

        [Display(ResourceType = typeof(UILocalization), Name = "ABNegative")]

        ABNegative,

        [Display(ResourceType = typeof(UILocalization), Name = "ANegative")]

        ANegative,

        [Display(ResourceType = typeof(UILocalization), Name = "BNegative")]

        BNegative,

        [Display(ResourceType = typeof(UILocalization), Name = "ONegative")]

        ONegative

    }
}
