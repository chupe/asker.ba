using AskerTracker.Application.Contracts.Persistence;
using FluentValidation;

namespace AskerTracker.Application.Features.Fees.Commands.CreateFees;

public class CreateFeeCommandValidator : AbstractFeeCommandValidator<CreateFeeCommand>
{
    public CreateFeeCommandValidator(IMemberRepository memberRepository) : base(memberRepository)
    {
        RuleFor(f => f.Amount)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);

        RuleFor(f => f.MemberId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MustAsync(MemberExits);

        RuleFor(f => f.TransactionDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .LessThan(DateTime.Now);
    }
}