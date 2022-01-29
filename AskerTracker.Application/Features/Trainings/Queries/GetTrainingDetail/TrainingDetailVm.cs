using AskerTracker.Domain.Entities;
using AskerTracker.Domain.Types;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingDetail;

public class TrainingDetailVm
{
    public Guid Id { get; set; }
    public DateTime DateHeld { get; set; }
    public Guid LocationId { get; set; }
    public EventLocation? Location { get; set; }
    public ICollection<MemberDto>? Participants { get; set; }
    public TrainingType TrainingType { get; set; }
    public EventLocationDto? EventLocation { get; set; }
}