using MediatR;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingsWithParticipantsList;

public class GetTrainingsWithParticipantsListQuery : IRequest<ICollection<TrainingWithParticipantsListVm>>
{
}