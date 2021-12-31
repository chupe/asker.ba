using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Resources.Localization;
using AskerTracker.Domain.Types;

namespace AskerTracker.Domain
{
    public class Member : EntityModel
    {
        private string jmbg;

        [Required]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20",
            MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20",
            MinimumLength = 3)]
        public string LastName { get; set; }

        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20",
            MinimumLength = 3)]
        public string Nickname { get; set; }

        [Required] [DataType(DataType.Date)] public DateTime DateJoined { get; set; }

        [DataType(DataType.Date)] public DateTime? DateLeft { get; set; }

        [Required] [DataType(DataType.Date)] public DateTime BirthDate { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to50",
            MinimumLength = 3)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(BloodType))]
        [EnumDataType(typeof(BloodType))]
        public BloodType BloodType { get; set; }
        
        public HashSet<Training> Trainings { get; set; } = new();
        
        public HashSet<TestingEvent> TestingEvents { get; set; } = new();

        public HashSet<MembershipFee> MembershipFees { get; set; } = new();
        
        public bool Active { get; set; }

        [Required]
        [StringLength(13, ErrorMessageResourceType = typeof(UILocalization),
            ErrorMessageResourceName = "PersonalIdMinLengthIs13", MinimumLength = 13)]
        public string JMBG
        {
            get => jmbg;
            set
            {
                if (value.Length != 13)
                    throw new Exception("Unique identifier (JMBG) needs to have 13 digit value");
                jmbg = value;
            }
        }

        [ScaffoldColumn(false)] public string FullName => $"{FirstName} {LastName}";
    }
}