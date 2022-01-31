using AskerTracker.Domain.Types;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Commands.CreateTraining;

public class CreateTrainingCommand : IRequest<CreateTrainingCommandResponse>
{
    public List<Guid>? ParticipantIds { get; set; }
    public Guid LocationId { get; set; }
    public DateTime DateHeld { get; set; }
    public TrainingType TrainingType { get; set; }
}