using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Items.Commands.UpdateItem;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Item> _itemRepository;

    public UpdateItemCommandHandler(IMapper mapper, IAsyncRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }
    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        // TODO: validation

        var itemToUpdate = await _itemRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, itemToUpdate, typeof(UpdateItemCommand), typeof(Item));

        await _itemRepository.UpdateAsync(itemToUpdate);

        return Unit.Value;
    }
}