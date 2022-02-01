using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Exceptions;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Fees.Commands.UpdateFees;

public class UpdateFeeCommandHandler : IRequestHandler<UpdateFeeCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<MembershipFee> _feeRepository;
    private readonly IMemberRepository _memberRepository;

    public UpdateFeeCommandHandler(IMapper mapper, IAsyncRepository<MembershipFee> feeRepository,
        IMemberRepository memberRepository)
    {
        _mapper = mapper;
        _feeRepository = feeRepository;
        _memberRepository = memberRepository;
    }
    public async Task<Unit> Handle(UpdateFeeCommand request, CancellationToken cancellationToken)
    {
        var feeToUpdate = await _feeRepository.GetByIdAsync(request.Id);
        
        if (feeToUpdate == null)
            throw new NotFoundException(nameof(MembershipFee), request.Id);

        _mapper.Map(request, feeToUpdate, typeof(UpdateFeeCommand), typeof(MembershipFee));

        var validator = new UpdateFeeCommandValidator(_memberRepository);
        var validationResult = await validator.ValidateAsync(feeToUpdate, cancellationToken);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);

        await _feeRepository.UpdateAsync(feeToUpdate);

        return Unit.Value;
    }
}