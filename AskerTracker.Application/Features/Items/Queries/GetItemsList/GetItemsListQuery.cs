using MediatR;

namespace AskerTracker.Application.Features.Items.Queries.GetItemsList;

public class GetItemsListQuery : IRequest<ICollection<ItemsListVm>>
{
}