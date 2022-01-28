using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Items.Queries.GetItemDetail;

public class GetItemDetailQueryHandler : IRequestHandler<GetItemDetailQuery, ItemDetailVm>
{
    private readonly IAsyncRepository<Item> _itemRepository;
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Member> _memberRepository;

    public GetItemDetailQueryHandler(IMapper mapper, IAsyncRepository<Item> itemRepository,
        IAsyncRepository<Member> memberRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
        _memberRepository = memberRepository;
    }

    public async Task<ItemDetailVm> Handle(GetItemDetailQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(request.Id);
        var itemDetailDto = _mapper.Map<ItemDetailVm>(item);

        var owner = item.OwnerId.HasValue ? await _memberRepository.GetByIdAsync(item.OwnerId.Value) : null;
        var lender = item.LenderId.HasValue ? await _memberRepository.GetByIdAsync(item.LenderId.Value) : null;

        // if (member == null)
        // {
        //     throw new NotFoundException(nameof(Fee), request.Id);
        // }

        itemDetailDto.Owner = _mapper.Map<MemberDto>(owner);
        itemDetailDto.Lender = _mapper.Map<MemberDto>(lender);

        return itemDetailDto;
    }
}