using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Exceptions;
using AskerTracker.Domain.Entities;
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
        var fees = (await _feesRepository.ListAllAsync()).OrderBy(x => x.TransactionDate);

        return _mapper.Map<ICollection<FeesListVm>>(fees);
    }
}