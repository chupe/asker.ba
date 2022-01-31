using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Features.SharedDtos;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingDetail;

public class GetTrainingDetailQueryHandler : IRequestHandler<GetTrainingDetailQuery, TrainingDetailVm>
{
    private readonly IAsyncRepository<EventLocation> _locationRepository;
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Member> _memberRepository;
    private readonly IAsyncRepository<Event> _trainingRepository;

    public GetTrainingDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> trainingRepository,
        IAsyncRepository<EventLocation> locationRepository, IAsyncRepository<Member> memberRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
        _locationRepository = locationRepository;
        _memberRepository = memberRepository;
    }

    public async Task<TrainingDetailVm> Handle(GetTrainingDetailQuery request, CancellationToken cancellationToken)
    {
        var training = await _trainingRepository.GetByIdAsync(request.Id);
        var trainingDetailDto = _mapper.Map<TrainingDetailVm>(training);

        var location = await _locationRepository.GetByIdAsync(training.LocationId);
        var participants =
            (await _memberRepository.ListAllAsync()).Where(p => training.ParticipantsIds.Contains(p.Id));

        // if (location == null)
        // {
        //     throw new NotFoundException(nameof(Training), request.Id);
        // }

        trainingDetailDto.EventLocation = _mapper.Map<EventLocationDto>(location);
        trainingDetailDto.Participants = _mapper.Map<ICollection<MemberDto>>(participants);

        return trainingDetailDto;
    }
}