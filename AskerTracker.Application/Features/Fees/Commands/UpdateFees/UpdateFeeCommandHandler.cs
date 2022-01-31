using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Fees.Commands.UpdateFees;

public class UpdateFeeCommandHandler : IRequestHandler<UpdateFeeCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<MembershipFee> _feeRepository;

    public UpdateFeeCommandHandler(IMapper mapper, IAsyncRepository<MembershipFee> feeRepository)
    {
        _mapper = mapper;
        _feeRepository = feeRepository;
    }
    public async Task<Unit> Handle(UpdateFeeCommand request, CancellationToken cancellationToken)
    {
        // TODO: validation

        var feeToUpdate = await _feeRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, feeToUpdate, typeof(UpdateFeeCommand), typeof(MembershipFee));

        await _feeRepository.UpdateAsync(feeToUpdate);

        return Unit.Value;
    }
}