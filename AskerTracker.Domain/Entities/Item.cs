using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Resources.Localization;

namespace AskerTracker.Domain.Entities;

public class Item : BaseEntity
{
    [Required]
    [StringLength(40, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to40",
        MinimumLength = 3)]
    public string Name { get; set; }

    [StringLength(200, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to200",
        MinimumLength = 3)]
    [DataType(DataType.Text)]
    public string Description { get; set; }

    [Required]
    [Range(1, 10000, ErrorMessageResourceType = typeof(UILocalization),
        ErrorMessageResourceName = "AmountOutOfRange")]
    public int Amount { get; set; }

    [StringLength(1000, ErrorMessageResourceType = typeof(UILocalization),
        ErrorMessageResourceName = "Length3to1000", MinimumLength = 3)]
    [DataType(DataType.MultilineText)]
    public string Comment { get; set; }

    [Range(1, 100000, ErrorMessageResourceType = typeof(UILocalization),
        ErrorMessageResourceName = "AmountOutOfRange")]
    [DataType(DataType.Currency)]
    public double Value { get; set; }

    [ForeignKey(nameof(Lender))] public Guid LenderId { get; set; }

    public Member Lender { get; set; }

    [ForeignKey(nameof(Owner))] public Guid OwnerId { get; set; }

    public Member Owner { get; set; }

    public DateTime LastTransactionDate { get; set; }

    public bool IsTeamProperty => Owner == null;
        
    [Required]
    public IEnumerable<ItemTransaction> ItemTransactions { get; set; } = new List<ItemTransaction>();
}