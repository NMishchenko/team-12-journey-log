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
        
        CreateMap<TravelLog, GetAllTravelLogsModel>();
        CreateMap<TravelLog, GetTravelLogModel>()
            .ForMember(model => model.Places, cfg => cfg.MapFrom(travelLog => travelLog.TravelLogPlaces));
        
        CreateMap<TravelLogPlace, GetPlace>()
            .ForMember(model => model.TravelNote, cfg => cfg.MapFrom(travelLogPlace => travelLogPlace.TravelNote));

        CreateMap<TravelNote, GetNote>()
            .ForMember(model => model.Photos, cfg => cfg.MapFrom(travelNote => travelNote.NotePhotos));

        CreateMap<NotePhoto, GetPhoto>();
    }
}