using MediatR;

namespace AskerTracker.Application.Features.Fees.Queries.GetFeesList;

public class GetFeesListQuery : IRequest<List<FeesListVm>>
{
}