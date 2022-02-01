using MediatR;

namespace AskerTracker.Application.Features.Members.Queries.GetMembersList;

public class GetMembersListQuery : IRequest<ICollection<MembersListVm>>
{
    public bool IncludeInactive { get; set; }
}