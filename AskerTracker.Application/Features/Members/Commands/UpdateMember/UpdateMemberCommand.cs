using AskerTracker.Domain.Types;
using MediatR;

namespace AskerTracker.Application.Features.Members.Commands.UpdateMember;

public class UpdateMemberCommand : IRequest
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Nickname { get; set; }
    public string? Jmbg { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime DateJoined { get; set; }
    public BloodType? BloodType { get; set; }
}