using AskerTracker.Application.Features.Fees.Commands.CreateFees;
using AskerTracker.Application.Features.Fees.Commands.UpdateFees;
using AskerTracker.Application.Features.Fees.Queries.GetFeeDetail;
using AskerTracker.Application.Features.Fees.Queries.GetFeesList;
using AskerTracker.Application.Features.Items.Commands.CreateItem;
using AskerTracker.Application.Features.Items.Commands.UpdateItem;
using AskerTracker.Application.Features.Items.Queries.GetItemDetail;
using AskerTracker.Application.Features.Items.Queries.GetItemsList;
using AskerTracker.Application.Features.Members.Commands.CreateMember;
using AskerTracker.Application.Features.Members.Commands.UpdateMember;
using AskerTracker.Application.Features.Members.Queries.GetMemberDetail;
using AskerTracker.Application.Features.Members.Queries.GetMembersList;
using AskerTracker.Application.Features.SharedDtos;
using AskerTracker.Application.Features.Trainings.Commands.CreateTraining;
using AskerTracker.Application.Features.Trainings.Commands.UpdateTraining;
using AskerTracker.Application.Features.Trainings.Queries.GetTrainingDetail;
using AskerTracker.Application.Features.Trainings.Queries.GetTrainingsList;
using AskerTracker.Application.Features.Trainings.Queries.GetTrainingsWithParticipantsList;
using AskerTracker.Domain.Entities;
using AutoMapper;

namespace AskerTracker.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Training, TrainingListVm>().ReverseMap();
        CreateMap<Training, TrainingDetailVm>().ReverseMap();
        CreateMap<Training, TrainingWithParticipantsListVm>().ReverseMap();
        CreateMap<Member, MembersListVm>().ReverseMap();
        CreateMap<Member, MemberDetailVm>().ReverseMap();
        CreateMap<MembershipFee, FeesListVm>().ReverseMap();
        CreateMap<MembershipFee, FeeDetailVm>().ReverseMap();
        CreateMap<Item, ItemsListVm>().ReverseMap();
        CreateMap<Item, ItemDetailVm>().ReverseMap();
        CreateMap<EventLocation, EventLocationDto>();
        CreateMap<Training, TrainingDto>();
        CreateMap<TestingResult, TestingResultDto>();
        CreateMap<Member, MemberDto>();
        CreateMap<MembershipFee, FeeDto>();
        CreateMap<Training, CreateTrainingCommand>().ReverseMap();
        CreateMap<Training, UpdateTrainingCommand>().ReverseMap();
        CreateMap<Member, CreateMemberCommand>().ReverseMap();
        CreateMap<Member, UpdateMemberCommand>().ReverseMap();
        CreateMap<Item, CreateItemCommand>().ReverseMap();
        CreateMap<Item, UpdateItemCommand>().ReverseMap();
        CreateMap<MembershipFee, CreateFeeCommand>().ReverseMap();
        CreateMap<MembershipFee, UpdateFeeCommand>().ReverseMap();
    }
}