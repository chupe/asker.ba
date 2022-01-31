using AskerTracker.Application.Contracts.Persistence;
using FluentValidation;

namespace AskerTracker.Application.Features.Fees.Commands.CreateFees;

public class CreateFeeCommandValidator : AbstractValidator<CreateFeeCommand>
{
    private readonly IMemberRepository _memberRepository;

    public CreateFeeCommandValidator(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
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

    private async Task<bool> MemberExits(Guid id, CancellationToken token)
    {
        return (await _memberRepository.ListAllAsync()).Any(m => m.Id == id);
    }
}