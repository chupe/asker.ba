using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Exceptions;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Fees.Commands.DeleteFees;

public class DeleteFeeCommandHandler : IRequestHandler<DeleteFeeCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<MembershipFee> _feeRepository;

    public DeleteFeeCommandHandler(IMapper mapper, IAsyncRepository<MembershipFee> feeRepository)
    {
        _mapper = mapper;
        _feeRepository = feeRepository;
    }

    public async Task<Unit> Handle(DeleteFeeCommand request, CancellationToken cancellationToken)
    {
        var feeToDelete = await _feeRepository.GetByIdAsync(request.Id);

        if (feeToDelete == null)
            throw new NotFoundException(nameof(MembershipFee), request.Id);

        await _feeRepository.DeleteAsync(feeToDelete);

        return Unit.Value;
    }
}