using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Features.SharedDtos;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Commands.CreateTraining;

public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, CreateTrainingCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Training> _trainingRepository;

    public CreateTrainingCommandHandler(IMapper mapper, IAsyncRepository<Training> trainingRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
    }

    public async Task<CreateTrainingCommandResponse> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTrainingCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        var response = new CreateTrainingCommandResponse();
        if (validationResult.Errors.Any())
        {
            response.Success = false;
            response.ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                response.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (response.Success)
        {
            var training = _mapper.Map<Training>(request);
            training = await _trainingRepository.AddAsync(training);
            response.Training = _mapper.Map<TrainingDto>(training);
        }

        return response;
    }
}