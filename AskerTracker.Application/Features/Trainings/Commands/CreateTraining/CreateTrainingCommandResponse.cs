using AskerTracker.Application.Features.SharedDtos;
using AskerTracker.Application.Responses;

namespace AskerTracker.Application.Features.Trainings.Commands.CreateTraining;

public class CreateTrainingCommandResponse : BaseResponse
{
    public TrainingDto? Training { get; set; }
}