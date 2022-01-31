using MediatR;

namespace AskerTracker.Application.Features.Members.Commands.DeleteMember;

public class DeleteMemberCommand : IRequest
{
    public Guid Id { get; set; }
}