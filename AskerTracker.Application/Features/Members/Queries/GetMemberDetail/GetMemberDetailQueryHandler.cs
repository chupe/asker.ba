using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Application.Exceptions;
using AskerTracker.Application.Features.SharedDtos;
using AskerTracker.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AskerTracker.Application.Features.Members.Queries.GetMemberDetail;

public class GetMemberDetailQueryHandler : IRequestHandler<GetMemberDetailQuery, MemberDetailVm>
{
    private readonly IAsyncRepository<MembershipFee> _feeRepository;
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Member> _memberRepository;
    private readonly IAsyncRepository<TestingResult> _testingResultsRepository;
    private readonly IAsyncRepository<Training> _trainingRepository;

    public GetMemberDetailQueryHandler(IMapper mapper, IAsyncRepository<Member> memberRepository,
        IAsyncRepository<Training> trainingRepository, IAsyncRepository<TestingResult> testingResultsRepository,
        IAsyncRepository<MembershipFee> feeRepository)
    {
        _mapper = mapper;
        _memberRepository = memberRepository;
        _trainingRepository = trainingRepository;
        _testingResultsRepository = testingResultsRepository;
        _feeRepository = feeRepository;
    }

    public async Task<MemberDetailVm> Handle(GetMemberDetailQuery request, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetByIdAsync(request.Id);
        
        if (member == null)
            throw new NotFoundException(nameof(Member), request.Id);
        
        var memberDetailDto = _mapper.Map<MemberDetailVm>(member);

        var trainings =
            (await _trainingRepository.ListAllAsync()).Where(t => t.ParticipantsIds.Contains(member.Id));
        var testingResults = (await _testingResultsRepository.ListAllAsync()).Where(t => t.MemberId == member.Id);
        var fees = (await _feeRepository.ListAllAsync()).Where(f => f.MemberId == member.Id);

        memberDetailDto.Trainings = _mapper.Map<ICollection<TrainingDto>>(trainings);
        memberDetailDto.TestingResults = _mapper.Map<ICollection<TestingResultDto>>(testingResults);
        memberDetailDto.Fees = _mapper.Map<ICollection<FeeDto>>(fees);

        return memberDetailDto;
    }
}