using AskerTracker.Application.Contracts.Persistence;
using FluentValidation;

namespace AskerTracker.Application.Features.Fees.Commands;

public abstract class AbstractFeeCommandValidator<T> : AbstractValidator<T>
{
    private readonly IMemberRepository _memberRepository;

    protected AbstractFeeCommandValidator(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    protected async Task<bool> MemberExits(Guid id, CancellationToken token)
    {
        return (await _memberRepository.ListAllAsync()).Any(m => m.Id == id);
    }
}