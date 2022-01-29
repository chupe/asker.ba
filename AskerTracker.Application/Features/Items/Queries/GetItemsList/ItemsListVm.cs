namespace AskerTracker.Application.Features.Items.Queries.GetItemsList;

public class ItemsListVm
{
    public Guid LenderId;
    public Guid OwnerId;
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public float Amount { get; set; }
}