﻿namespace AskerTracker.Application.Features.SharedDtos;

public class FeeDto
{
    public Guid MemberId;
    public Guid Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public float Amount { get; set; }
}