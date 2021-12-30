using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Resources.Localization;

namespace AskerTracker.Domain
{
    public class MembershipFee : EntityModel
    {
        [Required] [DataType(DataType.Date)] public DateTime TransactionDate { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessageResourceType = typeof(UILocalization),
            ErrorMessageResourceName = "AmountOutOfRange")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public float Amount { get; set; }

        [ForeignKey("Member")] [Required] public Guid MemberId { get; set; }

        public Member Member { get; set; }
    }
}