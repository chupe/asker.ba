using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Features.SharedDtos;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Fees.Queries.GetFeeDetail;

public class GetFeeDetailQueryHandler : IRequestHandler<GetFeeDetailQuery, FeeDetailVm>
{
    private readonly IAsyncRepository<MembershipFee> _feeRepository;
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Member> _memberRepository;

    public GetFeeDetailQueryHandler(IMapper mapper, IAsyncRepository<MembershipFee> feeRepository,
        IAsyncRepository<Member> memberRepository)
    {
        _mapper = mapper;
        _feeRepository = feeRepository;
        _memberRepository = memberRepository;
    }

    public async Task<FeeDetailVm> Handle(GetFeeDetailQuery request, CancellationToken cancellationToken)
    {
        var fee = await _feeRepository.GetByIdAsync(request.Id);
        var feeDetailDto = _mapper.Map<FeeDetailVm>(fee);

        var member = await _memberRepository.GetByIdAsync(fee.MemberId);

        // if (member == null)
        // {
        //     throw new NotFoundException(nameof(Fee), request.Id);
        // }

        feeDetailDto.Member = _mapper.Map<MemberDto>(member);

        return feeDetailDto;
    }
}