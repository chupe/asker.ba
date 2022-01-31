using FluentValidation;

namespace AskerTracker.Application.Features.Items.Commands.CreateItem;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .Length(3, 50).WithMessage("{PropertyName} needs to be between 3 and 50 characters long.");

        RuleFor(i => i.Amount)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);

        RuleFor(i => i.TransactionDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .LessThan(DateTime.Now);
        
        RuleFor(i => i.Description)
            .MaximumLength(3000).WithMessage("{PropertyName} can not exceed 3000 characters.");
    }
}