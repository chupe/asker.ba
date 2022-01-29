using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Features.Trainings.Queries.GetTrainingsList;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingsWithParticipantsList;

public class GetTrainingsWithParticipantsListQueryHandler : IRequestHandler<GetTrainingsWithParticipantsListQuery, ICollection<TrainingWithParticipantsListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Training> _trainingRepository;

    public GetTrainingsWithParticipantsListQueryHandler(IMapper mapper, IAsyncRepository<Training> trainingRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
    }

    public async Task<ICollection<TrainingWithParticipantsListVm>> Handle(GetTrainingsWithParticipantsListQuery request, CancellationToken cancellationToken)
    {
        var allTrainings = (await _trainingRepository.ListAllAsync()).OrderBy(x => x.DateHeld);
        return _mapper.Map<ICollection<TrainingWithParticipantsListVm>>(allTrainings);
    }
}