using System;
using System.ComponentModel.DataAnnotations;
using Asker.Resources.Localization;

namespace Asker.Models
{
    public class ItemTransaction : BaseModel
    {
        public ItemTransaction() : base() { }

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(TransactionDate))]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(Amount))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "AmountRequired")]
        [Range(1, 10000, ErrorMessageResourceName = "AmountOutOfRange")]
        public int Amount { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(Comment))]
        [StringLength(1000, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to1000", MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(OwnershipChange))]
        public bool OwnershipChange { get; set; } = false;

        [Display(ResourceType = typeof(UILocalization), Name = nameof(LenderId))]
        public Guid LenderId { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(OwnerId))]
        public Guid OwnerId { get; set; }
    }
}
