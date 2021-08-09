using System;
using System.ComponentModel.DataAnnotations;

using Asker.Resources.Localization;


namespace Asker.Models
{
    public class MembershipFee : BaseModel
    {
        public MembershipFee() : base() { }

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]

        [Display(ResourceType = typeof(UILocalization), Name = nameof(TransactionDate))]

        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(Amount))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "AmountRequired")]
        [Range(1, 10000, ErrorMessageResourceName = "AmountOutOfRange")]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(MemberId))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "MemberRequired")]
        public Guid MemberId { get; set; }
    }
}
