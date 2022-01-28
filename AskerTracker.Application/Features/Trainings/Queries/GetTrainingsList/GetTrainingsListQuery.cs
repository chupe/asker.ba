using MediatR;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingsList;

public class GetTrainingsListQuery : IRequest<List<TrainingListVm>>
{
}