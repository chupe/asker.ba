using MediatR;

namespace AskerTracker.Application.Features.Members.Queries.GetMemberDetail;

public class GetMemberDetailQuery : IRequest<MemberDetailVm>
{
    public Guid Id { get; set; }
}