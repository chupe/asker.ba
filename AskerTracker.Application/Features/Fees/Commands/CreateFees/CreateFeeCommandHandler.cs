using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Exceptions;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Fees.Commands.CreateFees;

public class CreateFeeCommandHandler : IRequestHandler<CreateFeeCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<MembershipFee> _feeRepository;
    private readonly IMemberRepository _memberRepository;

    public CreateFeeCommandHandler(IMapper mapper, IAsyncRepository<MembershipFee> feeRepository,
        IMemberRepository memberRepository)
    {
        _mapper = mapper;
        _feeRepository = feeRepository;
        _memberRepository = memberRepository;
    }
    public async Task<Guid> Handle(CreateFeeCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateFeeCommandValidator(_memberRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);
        
        var fee = _mapper.Map<MembershipFee>(request);

        fee = await _feeRepository.AddAsync(fee);

        return fee.Id;
    }
}