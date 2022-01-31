﻿using AskerTracker.Application.Features.SharedDtos;
using AskerTracker.Domain.Types;

namespace AskerTracker.Application.Features.Members.Queries.GetMemberDetail;

public class MemberDetailVm
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public string? Nickname { get; set; }
    public string? Jmbg { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime DateJoined { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool Active { get; set; }
    public BloodType BloodType{ get; set; }
    public ICollection<TrainingDto>? Trainings { get; set; }
    public ICollection<TestingResultDto>? TestingResults { get; set; }
    public ICollection<FeeDto>? Fees { get; set; }
}