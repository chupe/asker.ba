using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Exceptions;
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
        var trainingToUpdate = await _trainingRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, trainingToUpdate, typeof(UpdateTrainingCommand), typeof(Training));

        var validator = new UpdateTrainingCommandValidator();
        var validationResult = await validator.ValidateAsync(trainingToUpdate, cancellationToken);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);
        
        await _trainingRepository.UpdateAsync(trainingToUpdate);

        return Unit.Value;
    }
}