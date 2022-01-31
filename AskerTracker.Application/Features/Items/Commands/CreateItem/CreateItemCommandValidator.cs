using AskerTracker.Application.Contracts.Persistence;
using FluentValidation;

namespace AskerTracker.Application.Features.Items.Commands.CreateItem;

public class CreateItemCommandValidator : AbstractItemCommandValidator<CreateItemCommand>
{
    public CreateItemCommandValidator(IMemberRepository memberRepository) : base(memberRepository)
    {
        RuleFor(i => i.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .Length(3, 50).WithMessage("{PropertyName} needs to be between 3 and 50 characters long.");

        RuleFor(i => i.Amount)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);

        RuleFor(i => i.LastTransactionDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .LessThan(DateTime.Now);

        RuleFor(i => i.OwnerId)
            .MustAsync(MemberExits).When(i => i.OwnerId != Guid.Empty);
        
        RuleFor(i => i.LenderId)
            .MustAsync(MemberExits).When(i => i.OwnerId != Guid.Empty);
        
        RuleFor(i => i.Description)
            .MaximumLength(3000).WithMessage("{PropertyName} can not exceed 3000 characters.");
        
        RuleFor(i => i.Comment)
            .MaximumLength(3000).WithMessage("{PropertyName} can not exceed 3000 characters.");
    }
}