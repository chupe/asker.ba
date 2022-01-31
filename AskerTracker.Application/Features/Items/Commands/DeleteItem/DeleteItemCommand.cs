using MediatR;

namespace AskerTracker.Application.Features.Items.Commands.DeleteItem;

public class DeleteItemCommand : IRequest
{
    public Guid Id { get; set; }
}