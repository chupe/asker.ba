using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using FluentValidation;

namespace AskerTracker.Application.Features.Fees.Commands.UpdateFees;

public class UpdateFeeCommandValidator : AbstractFeeCommandValidator<MembershipFee>
{
    public UpdateFeeCommandValidator(IMemberRepository memberRepository) : base(memberRepository)
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