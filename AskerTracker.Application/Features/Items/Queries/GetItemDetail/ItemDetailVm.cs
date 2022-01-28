namespace AskerTracker.Application.Features.Items.Queries.GetItemDetail;

public class ItemDetailVm
{
    public Guid Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public float Amount { get; set; }
    public MemberDto? Owner { get; set; }
    public MemberDto? Lender { get; set; }
    public DateTime Created { get; set; }
}