using MediatR;

namespace AskerTracker.Application.Features.Trainings.Commands.DeleteTraining;

public class DeleteTrainingCommand : IRequest
{
    public Guid Id { get; set; }
}