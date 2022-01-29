using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingsList;

public class GetTrainingsListQueryHandler : IRequestHandler<GetTrainingsListQuery, ICollection<TrainingListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Training> _trainingRepository;

    public GetTrainingsListQueryHandler(IMapper mapper, IAsyncRepository<Training> trainingRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
    }

    public async Task<ICollection<TrainingListVm>> Handle(GetTrainingsListQuery request, CancellationToken cancellationToken)
    {
        var allTrainings = (await _trainingRepository.ListAllAsync()).OrderBy(x => x.DateHeld);
        return _mapper.Map<ICollection<TrainingListVm>>(allTrainings);
    }
}