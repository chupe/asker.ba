using System;
using System.ComponentModel.DataAnnotations;
using Asker.Resources;


namespace Asker.Models
{
    public class Member : BaseModel
    {
        public Member() : base() { }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(FirstName))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "FirstNameRequired")]
        [StringLength(15, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to15", MinimumLength = 3)]
        public string FirstName { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(LastName))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "LastNameRequired")]
        [StringLength(15, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to15", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]

        [Display(ResourceType = typeof(UILocalization), Name = nameof(JoinedDate))]

        [DataType(DataType.Date)]
        public DateTime JoinedDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]

        [Display(ResourceType = typeof(UILocalization), Name = nameof(BirthDate))]

        [DataType(DataType.Date)]
        [DisplayFormat()]
        public DateTime BirthDate { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [StringLength(40, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to40", MinimumLength = 3)]
        public string Email { get; set; }

        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "PhoneRequired")]

        [Display(ResourceType = typeof(UILocalization), Name = nameof(PhoneNumber))]

        public int PhoneNumber { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(BloodType))]

        [EnumDataType(typeof(TrainingType))]
        public BloodType BloodType { get; set; }

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "PersonalIdRequired")]
        [StringLength(13, ErrorMessageResourceName = "PersonalIdMinLengthIs13", MinimumLength = 13)]

        [Display(ResourceType = typeof(UILocalization), Name = nameof(JMBG))]

        public string JMBG { get; set; }

        [ScaffoldColumn(false)]

        [Display(ResourceType = typeof(UILocalization), Name = nameof(FullName))]

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            private set { }
        }
    }
}
