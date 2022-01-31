using FluentValidation;

namespace AskerTracker.Application.Features.Trainings.Commands.CreateTraining;

public class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
{
    public CreateTrainingCommandValidator()
    {
        RuleFor(t => t.TrainingType)
            .NotNull().WithMessage("{Property name} can not be empty.");
        
        RuleFor(t => t.DateHeld)
            .NotNull().WithMessage("{Property name} can not be empty.");
        
        RuleFor(t => t.LocationId)
            .NotNull().WithMessage("{Property name} can not be empty.");
        
        RuleFor(t => t.ParticipantIds)
            .NotNull().WithMessage("{Property name} can not be empty.")
            .NotEmpty();
    }
}