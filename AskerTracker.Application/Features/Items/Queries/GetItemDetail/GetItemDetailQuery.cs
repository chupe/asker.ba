using MediatR;

namespace AskerTracker.Application.Features.Items.Queries.GetItemDetail;

public class GetItemDetailQuery : IRequest<ItemDetailVm>
{
    public Guid Id { get; set; }
}