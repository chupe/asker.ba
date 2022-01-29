using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Items.Queries.GetItemsList;

public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, ICollection<ItemsListVm>>
{
    private readonly IAsyncRepository<Item> _itemsRepository;
    private readonly IMapper _mapper;

    public GetItemsListQueryHandler(IMapper mapper, IAsyncRepository<Item> itemsRepository)
    {
        _mapper = mapper;
        _itemsRepository = itemsRepository;
    }

    public async Task<ICollection<ItemsListVm>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
    {
        var allFees = (await _itemsRepository.ListAllAsync()).OrderBy(x => x.Name);
        return _mapper.Map<ICollection<ItemsListVm>>(allFees);
    }
}