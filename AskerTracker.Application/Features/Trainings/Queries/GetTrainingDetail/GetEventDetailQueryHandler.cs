using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Queries.GetTrainingDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetTrainingDetailQuery, TrainingDetailVm>
    {
        private readonly IAsyncRepository<Event> _trainingRepository;
        private readonly IAsyncRepository<EventLocation> _locationRepository;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> trainingRepository,
            IAsyncRepository<EventLocation> locationRepository)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
            _locationRepository = locationRepository;
        }

        public async Task<TrainingDetailVm> Handle(GetTrainingDetailQuery request, CancellationToken cancellationToken)
        {
            var training = await _trainingRepository.GetByIdAsync(request.Id);
            var trainingDetailDto = _mapper.Map<TrainingDetailVm>(training);

            var location = await _locationRepository.GetByIdAsync(training.LocationId);

            // if (location == null)
            // {
            //     throw new NotFoundException(nameof(Training), request.Id);
            // }

            trainingDetailDto.EventLocation = _mapper.Map<EventLocationDto>(location);

            return trainingDetailDto;
        }
    }
}