using System;
using System.ComponentModel.DataAnnotations;
using Asker.Resources;
using Asker.Types;

namespace Asker.Models
{
    public class Member : EntityModel
    {
        public Member() : base() { }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(FirstName))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "FirstNameRequired")]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(LastName))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "LastNameRequired")]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20", MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(Nickname))]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20", MinimumLength = 3)]
        public string Nickname { get; set; }

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(DateJoined))]
        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(DateLeft))]
        [DataType(DataType.Date)]
        public DateTime DateLeft { get; set; }

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(BirthDate))]
        [DataType(DataType.Date)]
        [DisplayFormat()]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to50", MinimumLength = 3)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "PhoneRequired")]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(BloodType))]
        [EnumDataType(typeof(BloodType))]
        public BloodType BloodType { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(Active))]
        public bool Active { get; set; }

        private string jmbg;

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "PersonalIdRequired")]
        [StringLength(13, ErrorMessageResourceName = "PersonalIdMinLengthIs13", MinimumLength = 13)]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(JMBG))]
        public string JMBG
        {
            get
            {
                return jmbg;
            }
            set
            {
                if (value.Length != 13)
                    throw new Exception("Unique identifier (JMBG) needs to have 13 digit value");
                else jmbg = value;
            }
        }

        [ScaffoldColumn(false)]
        [Required]
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
