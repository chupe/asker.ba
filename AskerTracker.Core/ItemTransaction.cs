﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AskerTracker.Core.BaseModels;
using AskerTracker.Core.Resources.Localization;

namespace AskerTracker.Core
{
    public class ItemTransaction : EntityModel
    {
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        // [Display(ResourceType = typeof(UILocalization), Name = nameof(TransactionDate))]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Amount))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "AmountRequired")]
        [Range(1, 10000, ErrorMessageResourceType = typeof(UILocalization),
            ErrorMessageResourceName = "AmountOutOfRange")]
        public int Amount { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Comment))]
        [StringLength(1000, ErrorMessageResourceType = typeof(UILocalization),
            ErrorMessageResourceName = "Length3to1000", MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(OwnershipChange))]
        public bool OwnershipChange { get; set; } = false;

        [ForeignKey("Lender")] public Guid? LenderId { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Lender))]
        public Member Lender { get; set; }

        [ForeignKey("Owner")] public Guid? OwnerId { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Owner))]
        public Member Owner { get; set; }
    }
}