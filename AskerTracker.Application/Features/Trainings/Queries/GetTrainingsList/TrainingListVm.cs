using AskerTracker.Domain.Types;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingsList;

public class TrainingListVm
{
    public Guid Id { get; set; }
    public DateTime DateHeld { get; set; }
    public TrainingType TrainingType { get; set; }
}