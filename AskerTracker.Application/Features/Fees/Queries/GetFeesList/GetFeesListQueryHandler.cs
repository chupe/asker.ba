using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Fees.Queries.GetFeesList;

public class GetFeesListQueryHandler : IRequestHandler<GetFeesListQuery, List<FeesListVm>>
{
    private readonly IAsyncRepository<MembershipFee> _feesRepository;
    private readonly IMapper _mapper;

    public GetFeesListQueryHandler(IMapper mapper, IAsyncRepository<MembershipFee> feesRepository)
    {
        _mapper = mapper;
        _feesRepository = feesRepository;
    }

    public async Task<List<FeesListVm>> Handle(GetFeesListQuery request, CancellationToken cancellationToken)
    {
        var allFees = (await _feesRepository.ListAllAsync()).OrderBy(x => x.TransactionDate);
        return _mapper.Map<List<FeesListVm>>(allFees);
    }
}