using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Types;

namespace AskerTracker.Domain.Entities;

public class Training : Event
{
    [Required]
    [EnumDataType(typeof(TrainingType))]
    public TrainingType TrainingType { get; set; }
}