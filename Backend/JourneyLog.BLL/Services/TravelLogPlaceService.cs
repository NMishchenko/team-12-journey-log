using AutoMapper;
using JourneyLog.BLL.Exceptions.BadRequestException;
using JourneyLog.BLL.Exceptions.NotFound;
using JourneyLog.BLL.Models.TravelLog;
using JourneyLog.BLL.Services.Interfaces;
using JourneyLog.DAL;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.BLL.Services;

public class TravelLogPlaceService : ITravelLogPlaceService
{
    private readonly ITravelLogPlaceRepository _travelLogPlaceRepository;
    private readonly IJourneyLogContext _journeyLogContext;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    
    public TravelLogPlaceService(ITravelLogPlaceRepository travelLogPlaceRepository,
        IJourneyLogContext journeyLogContext,
        ICurrentUserService currentUserService,
        IMapper mapper)
    {
        _travelLogPlaceRepository = travelLogPlaceRepository;
        _journeyLogContext = journeyLogContext;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }
    
    public async Task AddAsync(Guid travelLogId, string placeId, CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var travelLogPlace = await _travelLogPlaceRepository.GetByTravelLogIdAndPlaceIdWithTravelLogAsync(travelLogId, placeId);

        if (travelLogPlace is not null)
        {
            throw new NotFoundException($"Travel Log with id {travelLogId} and Place with id {placeId} have already been added");
        }

        if (travelLogPlace.TravelLog.UserId != currentUser.Id)
        {
            throw new BadRequestException($"Travel Log {travelLogId} belongs to another user");
        }

        await _travelLogPlaceRepository.AddAsync(travelLogPlace);
        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid travelLogId, string placeId, UpdateTravelLogPlaceInfoModel updateTravelLogPlaceInfoModel,
        CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var travelLogPlace = await _travelLogPlaceRepository.GetByTravelLogIdAndPlaceIdWithTravelLogAsync(travelLogId, placeId);

        if (travelLogPlace is null)
        {
            throw new NotFoundException($"Travel Log with id {travelLogId} or Place with id {placeId} not found");
        }

        if (travelLogPlace.TravelLog.UserId != currentUser.Id)
        {
            throw new BadRequestException($"Travel Log {travelLogId} belongs to another user");
        }
        
        travelLogPlace = _mapper.Map(updateTravelLogPlaceInfoModel, travelLogPlace);

        await _travelLogPlaceRepository.UpdateAsync(travelLogPlace);
        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid travelLogId, string placeId, CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var travelLogPlace = await _travelLogPlaceRepository.GetByTravelLogIdAndPlaceIdWithTravelLogAsync(travelLogId, placeId);

        if (travelLogPlace is null)
        {
            throw new NotFoundException($"Travel Log with id {travelLogId} or Place with id {placeId} not found");
        }

        if (travelLogPlace.TravelLog.UserId != currentUser.Id)
        {
            throw new BadRequestException($"Travel Log {travelLogId} belongs to another user");
        }

        await _travelLogPlaceRepository.DeleteByIdAsync(travelLogPlace.Id);
        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }
}