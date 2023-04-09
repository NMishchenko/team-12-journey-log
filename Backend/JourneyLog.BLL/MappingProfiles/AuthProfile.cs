using AutoMapper;
using JourneyLog.BLL.Models.Auth;
using JourneyLog.DAL.Entities;

namespace JourneyLog.BLL.MappingProfiles;

public class AuthProfile: Profile
{
    public AuthProfile()
    {
        CreateMap<SignupModel, User>()
            .ForMember(u => u.UserName, src => src.MapFrom(opt => opt.Email));
    }
}