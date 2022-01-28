using MediatR;

namespace AskerTracker.Application.Features.Fees.Queries.GetFeeDetail;

public class GetFeeDetailQuery : IRequest<FeeDetailVm>
{
    public Guid Id { get; set; }
}