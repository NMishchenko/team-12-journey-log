using AutoMapper;
using JourneyLog.BLL.Models.TravelLog;
using JourneyLog.BLL.Models.TravelLog.NestedModels;
using JourneyLog.DAL.Entities;

namespace JourneyLog.BLL.MappingProfiles;

public class TravelLogProfile : Profile
{
    public TravelLogProfile()
    {
        CreateMap<CreateTravelLogModel, TravelLog>();
        CreateMap<UpdateTravelLogModel, TravelLog>()
            .ForMember(travelLog => travelLog.CreationDate, cfg => cfg.Ignore());
        
        CreateMap<TravelLog, GetTravelLogModel>();
        CreateMap<TravelLogPlace, GetPlace>();
        CreateMap<TravelNote, GetNote>();
        CreateMap<NotePhoto, GetPhoto>();
    }
}