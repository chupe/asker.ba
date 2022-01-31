using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Commands.UpdateTraining;

public class UpdateTrainingCommandHandler : IRequestHandler<UpdateTrainingCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Training> _trainingRepository;

    public UpdateTrainingCommandHandler(IMapper mapper, IAsyncRepository<Training> trainingRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
    }
    public async Task<Unit> Handle(UpdateTrainingCommand request, CancellationToken cancellationToken)
    {
        // TODO: validation

        var trainingToUpdate = await _trainingRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, trainingToUpdate, typeof(UpdateTrainingCommand), typeof(Training));

        await _trainingRepository.UpdateAsync(trainingToUpdate);

        return Unit.Value;
    }
}