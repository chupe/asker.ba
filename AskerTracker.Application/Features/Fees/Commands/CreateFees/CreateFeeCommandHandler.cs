using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Fees.Commands.CreateFees;

public class CreateFeeCommandHandler : IRequestHandler<CreateFeeCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<MembershipFee> _feeRepository;

    public CreateFeeCommandHandler(IMapper mapper, IAsyncRepository<MembershipFee> feeRepository)
    {
        _mapper = mapper;
        _feeRepository = feeRepository;
    }
    public async Task<Guid> Handle(CreateFeeCommand request, CancellationToken cancellationToken)
    {
        var fee = _mapper.Map<MembershipFee>(request);

        fee = await _feeRepository.AddAsync(fee);

        return fee.Id;
    }
}