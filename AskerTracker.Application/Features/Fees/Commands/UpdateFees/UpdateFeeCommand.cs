using MediatR;

namespace AskerTracker.Application.Features.Fees.Commands.UpdateFees;

public class UpdateFeeCommand : IRequest
{
    public Guid Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public float Amount { get; set; }
    public Guid MemberId { get; set; }
    public DateTime Created { get; set; }
}