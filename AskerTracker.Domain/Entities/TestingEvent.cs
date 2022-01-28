using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.BaseModels;

namespace AskerTracker.Domain.Entities;

public class TestingEvent : Event
{
    [Required]
    public List<TestingResult> Results { get; set; }
}