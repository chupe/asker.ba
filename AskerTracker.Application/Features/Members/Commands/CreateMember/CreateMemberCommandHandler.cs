using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Members.Commands.CreateMember;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Member> _memberRepository;

    public CreateMemberCommandHandler(IMapper mapper, IAsyncRepository<Member> memberRepository)
    {
        _mapper = mapper;
        _memberRepository = memberRepository;
    }
    public async Task<Guid> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = _mapper.Map<Member>(request);

        member = await _memberRepository.AddAsync(member);

        return member.Id;
    }
}