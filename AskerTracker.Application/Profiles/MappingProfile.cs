using AskerTracker.Application.Features.Trainings.Queries.GetTrainingDetail;
using AskerTracker.Application.Features.Trainings.Queries.GetTrainingsList;
using AskerTracker.Domain.Entities;
using AutoMapper;

namespace AskerTracker.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Training, TrainingListVm>().ReverseMap();
        CreateMap<Training, TrainingDetailVm>().ReverseMap();
        CreateMap<EventLocation, EventLocationDto>();
    }
}