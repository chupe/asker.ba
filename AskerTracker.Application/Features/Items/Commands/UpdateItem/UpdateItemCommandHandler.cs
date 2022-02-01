using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Exceptions;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Items.Commands.UpdateItem;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Item> _itemRepository;
    private readonly IMemberRepository _memberRepository;

    public UpdateItemCommandHandler(IMapper mapper, IAsyncRepository<Item> itemRepository,
        IMemberRepository memberRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
        _memberRepository = memberRepository;
    }
    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var itemToUpdate = await _itemRepository.GetByIdAsync(request.Id);
        
        if (itemToUpdate == null)
            throw new NotFoundException(nameof(Item), request.Id);
        
        _mapper.Map(request, itemToUpdate, typeof(UpdateItemCommand), typeof(Item));

        var validator = new UpdateItemCommandValidator(_memberRepository);
        var validationResult = await validator.ValidateAsync(itemToUpdate, cancellationToken);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);

        await _itemRepository.UpdateAsync(itemToUpdate);

        return Unit.Value;
    }
}