using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Members.Commands.DeleteMember;

public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Member> _memberRepository;

    public DeleteMemberCommandHandler(IMapper mapper, IAsyncRepository<Member> memberRepository)
    {
        _mapper = mapper;
        _memberRepository = memberRepository;
    }

    public async Task<Unit> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var memberToDelete = await _memberRepository.GetByIdAsync(request.Id);

        await _memberRepository.DeleteAsync(memberToDelete);

        return Unit.Value;
    }
}