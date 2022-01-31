using AskerTracker.Application.Features.Trainings.Commands.CreateTraining;
using AskerTracker.Domain.Entities;
using FluentValidation;

namespace AskerTracker.Application.Features.Trainings.Commands.UpdateTraining;

public class UpdateTrainingCommandValidator : AbstractValidator<Training>
{
    public UpdateTrainingCommandValidator()
    {
        RuleFor(t => t.TrainingType)
            .NotNull().WithMessage("{Property name} can not be empty.");

        RuleFor(t => t.DateHeld)
            .NotNull().WithMessage("{Property name} can not be empty.")
            .NotEqual(DateTime.MinValue);
        
        RuleFor(t => t.LocationId)
            .NotNull().WithMessage("{Property name} can not be empty.");
        
        RuleFor(t => t.ParticipantsIds)
            .NotNull().WithMessage("{Property name} can not be empty.")
            .NotEmpty();
    }
}