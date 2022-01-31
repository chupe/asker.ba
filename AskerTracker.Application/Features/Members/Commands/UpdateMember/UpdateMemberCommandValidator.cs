using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Features.Members.Commands.CreateMember;
using AskerTracker.Domain.Entities;
using FluentValidation;

namespace AskerTracker.Application.Features.Members.Commands.UpdateMember;

public class UpdateMemberCommandValidator : AbstractValidator<Member>
{
    public UpdateMemberCommandValidator()
    {
        RuleFor(m => m.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(20).WithMessage("{PropertyName} must be between 3 and 20 characters.")
            .MinimumLength(3);
        
        RuleFor(m => m.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(20).WithMessage("{PropertyName} must be between 3 and 20 characters.")
            .MinimumLength(3);

        RuleFor(m => m.DateJoined)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .LessThan(DateTime.Now);

        RuleFor(m => m.Jmbg)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .Length(13).WithMessage("{PropertyName} must 13 characters long.");
    }
}