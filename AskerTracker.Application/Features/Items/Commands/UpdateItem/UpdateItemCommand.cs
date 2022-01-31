using MediatR;

namespace AskerTracker.Application.Features.Items.Commands.UpdateItem;

public class UpdateItemCommand : IRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Comment { get; set; }
    public float Amount { get; set; }
    public double Value { get; set; }
    public Guid OwnerId { get; set; }
    public Guid LenderId { get; set; }
}