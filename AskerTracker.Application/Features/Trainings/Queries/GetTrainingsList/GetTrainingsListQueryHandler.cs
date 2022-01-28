using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingsList;

public class GetTrainingsListQueryHandler : IRequestHandler<GetTrainingsListQuery, List<TrainingListVm>>
{
    private readonly IAsyncRepository<Training> _trainingRepository;
    private readonly IMapper _mapper;

    public GetTrainingsListQueryHandler(IMapper mapper, IAsyncRepository<Training> trainingRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
    }

    public async Task<List<TrainingListVm>> Handle(GetTrainingsListQuery request, CancellationToken cancellationToken)
    {
        var allTrainings = (await _trainingRepository.ListAllAsync()).OrderBy(x => x.DateHeld);
        return _mapper.Map<List<TrainingListVm>>(allTrainings);
    }
}