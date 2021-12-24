using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AskerTracker.Core.BaseModels;
using AskerTracker.Core.Resources.Localization;

namespace AskerTracker.Core
{
    public class MembershipFee : EntityModel
    {
        public MembershipFee() : base() { }

        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(TransactionDate))]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Amount))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "AmountRequired")]
        [Range(1, 10000, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "AmountOutOfRange")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float Amount { get; set; }

        [ForeignKey("Member")]
        [Required]
        public Guid MemberId { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Member))]
        // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "MemberRequired")]
        public Member Member { get; set; }
    }
}
