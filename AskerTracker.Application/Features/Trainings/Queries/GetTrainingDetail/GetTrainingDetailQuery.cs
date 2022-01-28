using MediatR;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingDetail
{
    public class GetTrainingDetailQuery: IRequest<TrainingDetailVm>
    {
        public Guid Id { get; set; }
    }
}
