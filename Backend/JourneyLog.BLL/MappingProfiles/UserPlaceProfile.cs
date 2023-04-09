using AutoMapper;
using JourneyLog.BLL.Models.Place;
using JourneyLog.DAL.Entities;

namespace JourneyLog.BLL.MappingProfiles;

public class UserPlaceProfile : Profile
{
    public UserPlaceProfile()
    {
        CreateMap<CreateUpdatePlaceReview, UserPlace>();
        CreateMap<CreateUpdatePlaceRating, UserPlace>();
    }
}