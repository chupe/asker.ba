using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AskerTracker.Domain.BaseModels;

namespace AskerTracker.Domain.Entities;

public class ASquad : EntityModel
{
    [Required] public ICollection<Member> Members { get; set; } = new List<Member>();
}