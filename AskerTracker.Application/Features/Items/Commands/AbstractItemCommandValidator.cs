using AskerTracker.Application.Contracts.Persistence;
using FluentValidation;

namespace AskerTracker.Application.Features.Items.Commands;

public abstract class AbstractItemCommandValidator<T> : AbstractValidator<T>
{
    private readonly IMemberRepository _memberRepository;

    protected AbstractItemCommandValidator(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    protected async Task<bool> MemberExits(Guid id, CancellationToken token)
    {
        return (await _memberRepository.ListAllAsync()).Any(m => m.Id == id);
    }
}