using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Commands.CreateTraining;

public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Training> _trainingRepository;

    public CreateTrainingCommandHandler(IMapper mapper, IAsyncRepository<Training> trainingRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
    }
    public async Task<Guid> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
    {
        var training = _mapper.Map<Training>(request);

        training = await _trainingRepository.AddAsync(training);

        return training.Id;
    }
}