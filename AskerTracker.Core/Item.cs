using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AskerTracker.Core.BaseModels;
using AskerTracker.Core.Resources.Localization;

namespace AskerTracker.Core
{
    public class Item : EntityModel
    {
        private Member owner;

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Name))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "NameRequired")]
        [StringLength(40, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to40",
            MinimumLength = 3)]
        public string Name { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Description))]
        [StringLength(200, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to200",
            MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Amount))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "AmountRequired")]
        [Range(1, 10000, ErrorMessageResourceType = typeof(UILocalization),
            ErrorMessageResourceName = "AmountOutOfRange")]
        public double Amount { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Comment))]
        [StringLength(1000, ErrorMessageResourceType = typeof(UILocalization),
            ErrorMessageResourceName = "Length3to1000", MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Value))]
        [Range(1, 100000, ErrorMessageResourceType = typeof(UILocalization),
            ErrorMessageResourceName = "AmountOutOfRange")]
        [DataType(DataType.Currency)]
        public double Value { get; set; }

        [ForeignKey("Lender")] public Guid? LenderId { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Lender))]
        public Member Lender { get; set; }

        [ForeignKey("Owner")] public Guid? OwnerId { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Owner))]
        public Member Owner
        {
            get => owner;
            set
            {
                if (value != null)
                {
                    owner = value;
                    IsTeamProperty = false;
                }
                else
                {
                    owner = null;
                    IsTeamProperty = true;
                }
            }
        }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(IsTeamProperty))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "TeamPropertyRequired")]
        public bool IsTeamProperty { get; set; }
    }
}