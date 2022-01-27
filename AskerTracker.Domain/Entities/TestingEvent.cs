using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.BaseModels;

namespace AskerTracker.Domain.Entities;

public class TestingEvent : EventModel
{
    [Required]
    public List<TestingResult> Results { get; set; }
}