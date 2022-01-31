using AskerTracker.Application.Features.Members.Queries.GetMemberDetail;
using AskerTracker.Domain.Types;
using MediatR;

namespace AskerTracker.Application.Features.Members.Commands.CreateMember;

public class CreateMemberCommand : IRequest<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Nickname { get; set; }
    public string? Jmbg { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime DateJoined { get; set; }
    public BloodType? BloodType { get; set; }
}