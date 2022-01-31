using AskerTracker.Domain.Types;

namespace AskerTracker.Application.Features.SharedDtos;

public class TestingResultDto
{
    public Guid Id { get; set; }
    public DateTime DateHeld { get; set; }
    public TrainingType TrainingType { get; set; }
}