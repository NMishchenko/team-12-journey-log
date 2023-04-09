using AutoMapper;
using JourneyLog.BLL.Models.TravelLog;
using JourneyLog.DAL.Entities;

namespace JourneyLog.BLL.MappingProfiles;

public class TravelLogPlaceProfile : Profile
{
    public TravelLogPlaceProfile()
    {
        CreateMap<UpdateTravelLogPlaceInfoModel, TravelLogPlace>();
    }
}