using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Exceptions;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Items.Commands.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Item> _itemRepository;

    public CreateItemCommandHandler(IMapper mapper, IAsyncRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }
    public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateItemCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);
        
        var item = _mapper.Map<Item>(request);

        item = await _itemRepository.AddAsync(item);

        return item.Id;
    }
}