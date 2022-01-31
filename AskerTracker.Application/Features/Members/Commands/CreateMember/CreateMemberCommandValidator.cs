using AskerTracker.Application.Contracts.Persistence;
using FluentValidation;

namespace AskerTracker.Application.Features.Members.Commands.CreateMember;

public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    private readonly IMemberRepository _memberRepository;

    public CreateMemberCommandValidator(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
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

        RuleFor(m => m)
            .MustAsync(MemberNameAndJmbgUnique)
            .WithMessage("Member with the same name and JMBG already exists.");
    }

    private async Task<bool> MemberNameAndJmbgUnique(CreateMemberCommand m, CancellationToken token)
    {
        return !await _memberRepository.IsMemberNameAndJmbgUnique($"{m.FirstName} {m.LastName}", m.Jmbg!);
    }
}