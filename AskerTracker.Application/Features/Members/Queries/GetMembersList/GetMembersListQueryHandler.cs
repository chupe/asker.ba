using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Members.Queries.GetMembersList;

public class GetMembersListQueryHandler : IRequestHandler<GetMembersListQuery, ICollection<MembersListVm>>
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _membersRepository;

    public GetMembersListQueryHandler(IMapper mapper, IMemberRepository membersRepository)
    {
        _mapper = mapper;
        _membersRepository = membersRepository;
    }

    public async Task<ICollection<MembersListVm>> Handle(GetMembersListQuery request, CancellationToken cancellationToken)
    {
        var allMembers = request.IncludeInactive
            ? (await _membersRepository.ListAllAsync()).OrderBy(x => x.FullName)
            : (await _membersRepository.ListAllAsync(request.IncludeInactive)).OrderBy(x => x.FullName);       
        
        return _mapper.Map<ICollection<MembersListVm>>(allMembers);
    }
}