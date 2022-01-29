namespace AskerTracker.Application.Features.Members.Queries.GetMembersList;

public class MembersListVm
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public string? Nickname { get; set; }
}