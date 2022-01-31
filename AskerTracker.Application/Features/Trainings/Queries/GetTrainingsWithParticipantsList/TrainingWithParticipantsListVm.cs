using AskerTracker.Application.Features.SharedDtos;
using AskerTracker.Domain.Types;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingsWithParticipantsList;

public class TrainingWithParticipantsListVm
{
    public Guid Id { get; set; }
    public DateTime DateHeld { get; set; }
    public TrainingType TrainingType { get; set; }
    public ICollection<MemberDto>? Participants { get; set; }
}