using AskerTracker.Domain.Types;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Commands.UpdateTraining;

public class UpdateTrainingCommand : IRequest
{
    public Guid Id { get; set; }
    public List<Guid>? ParticipantIds { get; set; }
    public Guid LocationId { get; set; }
    public DateTime DateHeld { get; set; }
    public TrainingType TrainingType { get; set; }
}