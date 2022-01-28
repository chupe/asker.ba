namespace AskerTracker.Application.Features.Members.Queries.GetMemberDetail;

public class MemberDetailVm
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string? Nickname { get; set; }
    public string JMBG { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateJoined { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool Active { get; set; }
    public List<TrainingDto> Trainings { get; set; }
    public List<TestingResultDto> TestingResults { get; set; }
    public List<FeeDto> Fees { get; set; }
}