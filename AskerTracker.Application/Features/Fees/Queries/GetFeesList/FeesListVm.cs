namespace AskerTracker.Application.Features.Fees.Queries.GetFeesList;

public class FeesListVm
{
    public Guid MemberId;
    public Guid Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public float Amount { get; set; }
}