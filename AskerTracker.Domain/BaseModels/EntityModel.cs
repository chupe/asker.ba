using System;
using System.ComponentModel.DataAnnotations;

namespace AskerTracker.Domain.BaseModels;

public class EntityModel
{
    public EntityModel()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.Now;
    }

    [Key] [ScaffoldColumn(false)] public Guid Id { get; set; }

    [Required]
    [ScaffoldColumn(false)]
    [DataType(DataType.DateTime)]
    private DateTime CreatedDate { get; }
}