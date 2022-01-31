using MediatR;

namespace AskerTracker.Application.Features.Fees.Queries.GetFeesList;

public class GetFeesListQuery : IRequest<ICollection<FeesListVm>>
{
    public bool IncludeInactive { get; set; }
}