using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Members.Commands.UpdateMember;

public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Member> _memberRepository;

    public UpdateMemberCommandHandler(IMapper mapper, IAsyncRepository<Member> memberRepository)
    {
        _mapper = mapper;
        _memberRepository = memberRepository;
    }
    public async Task<Unit> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        // TODO: validation
        var memberToUpdate = await _memberRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, memberToUpdate, typeof(UpdateMemberCommand), typeof(Member));

        await _memberRepository.UpdateAsync(memberToUpdate);

        return Unit.Value;
    }
}