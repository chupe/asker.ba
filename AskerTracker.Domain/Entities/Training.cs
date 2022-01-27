using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Types;

namespace AskerTracker.Domain.Entities;

public class Training : EventModel
{
    [Required]
    [EnumDataType(typeof(TrainingType))]
    public TrainingType TrainingType { get; set; }
}