using System;
using System.ComponentModel.DataAnnotations;
using Asker.Resources;


namespace Asker.Models
{
    public class Item : BaseModel
    {
        public Item() : base() { }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(Name))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "NameRequired")]
        [StringLength(15, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to15", MinimumLength = 3)]
        public string Name { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(Description))]

        [StringLength(200, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to200", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Description { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(Amount))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "AmountRequired")]
        [Range(1, 10000, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "AmountOutOfRange")]
        public int Amount { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(Comment))]

        [StringLength(1000, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to1000", MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(Value))]

        [Range(1, 100000, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "AmountOutOfRange")]
        [DataType(DataType.Currency)]
        public int Value { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(LenderId))]

        public Guid LenderId { get; set; }

        private Guid ownerId;


        [Display(ResourceType = typeof(UILocalization), Name = nameof(OwnerId))]

        public Guid OwnerId
        {
            get { return ownerId; }
            set
            {
                if (value != Guid.Empty)
                {
                    ownerId = value;
                    IsTeamProperty = false;
                }
                else
                {
                    ownerId = Guid.Empty;
                    IsTeamProperty = true;
                }
            }
        }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(IsTeamProperty))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "TeamPropertyRequired")]
        public bool IsTeamProperty { get; set; }
    }
}
