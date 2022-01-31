using AskerTracker.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Fees.Queries.GetFeesList;

public class GetFeesListQueryHandler : IRequestHandler<GetFeesListQuery, ICollection<FeesListVm>>
{
    private readonly IFeesRepository _feesRepository;
    private readonly IMapper _mapper;

    public GetFeesListQueryHandler(IMapper mapper, IFeesRepository feesRepository)
    {
        _mapper = mapper;
        _feesRepository = feesRepository;
    }

    public async Task<ICollection<FeesListVm>> Handle(GetFeesListQuery request, CancellationToken cancellationToken)
    {
        var fees = request.IncludeInactive
            ? (await _feesRepository.ListAllAsync()).OrderBy(x => x.TransactionDate)
            : (await _feesRepository.ListAllAsync(request.IncludeInactive)).OrderBy(x => x.TransactionDate);

        return _mapper.Map<ICollection<FeesListVm>>(fees);
    }
}