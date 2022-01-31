using MediatR;

namespace AskerTracker.Application.Features.Fees.Commands.DeleteFees;

public class DeleteFeeCommand : IRequest
{
    public Guid Id { get; set; }
}