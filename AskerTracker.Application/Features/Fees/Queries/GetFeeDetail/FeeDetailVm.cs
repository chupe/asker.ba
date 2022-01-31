using AskerTracker.Application.Features.SharedDtos;

namespace AskerTracker.Application.Features.Fees.Queries.GetFeeDetail;

public class FeeDetailVm
{
    public Guid MemberId;
    public Guid Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public float Amount { get; set; }
    public MemberDto? Member { get; set; }
    public DateTime Created { get; set; }
}