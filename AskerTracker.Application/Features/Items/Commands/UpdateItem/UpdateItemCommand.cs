using AskerTracker.Domain.Types;
using MediatR;

namespace AskerTracker.Application.Features.Items.Commands.UpdateItem;

public class UpdateItemCommand : IRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime TransactionDate { get; set; }
    public float Amount { get; set; }
    public Guid? OwnerId { get; set; }
    public Guid? LenderId { get; set; }
}