using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Resources.Localization;

namespace AskerTracker.Domain.Entities;

public class ItemTransaction : EntityModel
{
    [ForeignKey(nameof(Item))]
    [Required]
    public Guid? ItemId { get; set; }

    [Required] public Item Item { get; set; }

    [DataType(DataType.Date)] public DateTime TransactionDate { get; set; }

    [Required]
    [Range(1, 10000, ErrorMessageResourceType = typeof(UILocalization),
        ErrorMessageResourceName = "AmountOutOfRange")]
    public int Amount { get; set; }

    [StringLength(1000, ErrorMessageResourceType = typeof(UILocalization),
        ErrorMessageResourceName = "Length3to1000", MinimumLength = 3)]
    [DataType(DataType.MultilineText)]
    public string Comment { get; set; }

    [Required] public bool OwnershipChange { get; set; }

    [ForeignKey(nameof(Lender))]
    public Guid? LenderId { get; set; }

    public Member Lender { get; set; }

    [ForeignKey(nameof(Owner))]
    public Guid? OwnerId { get; set; }

    public Member Owner { get; set; }

    [ForeignKey(nameof(Previous))]
    public Guid? PreviousId { get; set; }

    public ItemTransaction Previous { get; set; }

    public ItemTransaction Next { get; set; }
}