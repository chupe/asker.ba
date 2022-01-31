using MediatR;

namespace AskerTracker.Application.Features.Fees.Commands.CreateFees;

public class CreateFeeCommand : IRequest<Guid>
{
    public DateTime TransactionDate { get; set; }
    public float Amount { get; set; }
    public Guid MemberId { get; set; }
    public DateTime Created { get; set; }
}