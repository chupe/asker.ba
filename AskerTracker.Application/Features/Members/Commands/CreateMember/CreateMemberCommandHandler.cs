using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Members.Commands.CreateMember;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _memberRepository;

    public CreateMemberCommandHandler(IMapper mapper, IMemberRepository memberRepository)
    {
        _mapper = mapper;
        _memberRepository = memberRepository;
    }
    public async Task<Guid> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateMemberCommandValidator(_memberRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new Exceptions.ValidationException(validationResult);
        
        var member = _mapper.Map<Member>(request);

        member = await _memberRepository.AddAsync(member);

        return member.Id;
    }
}