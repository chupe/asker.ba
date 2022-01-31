using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AskerTracker.Domain.Entities;
using AskerTracker.Domain.Resources.Localization;

namespace AskerTracker.Domain.BaseModels;

public class Event : BaseEntity
{
    [ForeignKey(nameof(Location))] public Guid LocationId { get; set; }

    [Required]
    public EventLocation Location { get; set; }

    [Required] [DataType(DataType.Date)] public DateTime DateHeld { get; set; }

    private HashSet<Member> participants = new ();
    [Required] public HashSet<Member> Participants
    {
        get => participants;
        set
        {
            participants = value;
            foreach (var participant in participants)
            {
                ParticipantsIds.Add(participant.Id);
            }
        }
    }

    [Required] public HashSet<Guid> ParticipantsIds { get; set; }
}