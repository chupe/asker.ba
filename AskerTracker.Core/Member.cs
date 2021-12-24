﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AskerTracker.Core.BaseModels;
using AskerTracker.Core.Resources.Localization;
using AskerTracker.Core.Types;

namespace AskerTracker.Core
{
    public class Member : EntityModel
    {
        private string jmbg;

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(FirstName))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "FirstNameRequired")]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20",
            MinimumLength = 3)]
        public string FirstName { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(LastName))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "LastNameRequired")]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20",
            MinimumLength = 3)]
        public string LastName { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Nickname))]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20",
            MinimumLength = 3)]
        public string Nickname { get; set; }

        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(DateJoined))]
        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(DateLeft))]
        [DataType(DataType.Date)] public DateTime? DateLeft { get; set; }

        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(BirthDate))]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to50",
            MinimumLength = 3)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "PhoneRequired")]
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(BloodType))]
        [EnumDataType(typeof(BloodType))]
        public BloodType BloodType { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Active))]
        public bool Active { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Transactions))]
        public ICollection<MembershipFee> Fees { get; set; }

        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "PersonalIdRequired")]
        [StringLength(13, ErrorMessageResourceType = typeof(UILocalization),
            ErrorMessageResourceName = "PersonalIdMinLengthIs13", MinimumLength = 13)]
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(JMBG))]
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

        [ScaffoldColumn(false)]
        [Required]
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(FullName))]
        public string FullName
        {
            get => FirstName + " " + LastName;
            private set { }
        }
    }
}