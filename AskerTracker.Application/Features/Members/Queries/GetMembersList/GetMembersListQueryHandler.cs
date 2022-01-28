using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Members.Queries.GetMembersList;

public class GetMembersListQueryHandler : IRequestHandler<GetMembersListQuery, List<MembersListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Member> _membersRepository;

    public GetMembersListQueryHandler(IMapper mapper, IAsyncRepository<Member> membersRepository)
    {
        _mapper = mapper;
        _membersRepository = membersRepository;
    }

    public async Task<List<MembersListVm>> Handle(GetMembersListQuery request, CancellationToken cancellationToken)
    {
        var allMembers = (await _membersRepository.ListAllAsync()).OrderBy(x => x.FullName);
        return _mapper.Map<List<MembersListVm>>(allMembers);
    }
}