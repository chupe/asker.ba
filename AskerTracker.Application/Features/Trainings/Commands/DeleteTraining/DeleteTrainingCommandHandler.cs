using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Trainings.Commands.DeleteTraining;

public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Training> _trainingRepository;

    public DeleteTrainingCommandHandler(IMapper mapper, IAsyncRepository<Training> trainingRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
    }

    public async Task<Unit> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
    {
        var trainingToDelete = await _trainingRepository.GetByIdAsync(request.Id);

        await _trainingRepository.DeleteAsync(trainingToDelete);
        
        return Unit.Value;
    }
}