using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Exceptions;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Items.Commands.DeleteItem;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Item> _itemRepository;

    public DeleteItemCommandHandler(IMapper mapper, IAsyncRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var itemToDelete = await _itemRepository.GetByIdAsync(request.Id);

        if (itemToDelete == null)
            throw new NotFoundException(nameof(Item), request.Id);
        
        await _itemRepository.DeleteAsync(itemToDelete);

        return Unit.Value;
    }
}