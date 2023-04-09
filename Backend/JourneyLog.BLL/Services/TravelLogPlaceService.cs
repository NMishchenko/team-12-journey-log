using AutoMapper;
using JourneyLog.BLL.Exceptions.BadRequestException;
using JourneyLog.BLL.Exceptions.NotFound;
using JourneyLog.BLL.Models.TravelLog;
using JourneyLog.BLL.Services.Interfaces;
using JourneyLog.DAL;
using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.BLL.Services;

public class TravelLogPlaceService : ITravelLogPlaceService
{
    private readonly ITravelLogPlaceRepository _travelLogPlaceRepository;
    private readonly ITravelLogRepository _travelLogRepository;
    private readonly JourneyLogContext _journeyLogContext;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    
    public TravelLogPlaceService(ITravelLogPlaceRepository travelLogPlaceRepository,
        ITravelLogRepository travelLogRepository,
        JourneyLogContext journeyLogContext,
        ICurrentUserService currentUserService,
        IMapper mapper)
    {
        _travelLogPlaceRepository = travelLogPlaceRepository;
        _travelLogRepository = travelLogRepository;
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
            throw new BadRequestException($"Travel Log with id {travelLogId} already has Place with id {placeId}");
        }
        
        var travelLog = await _travelLogRepository.GetByIdAsync(travelLogId);
        if (travelLog is null) throw new NotFoundException($"Travel Log {travelLogId} not found");

        if (travelLog.UserId != currentUser.Id)
        {
            throw new BadRequestException($"Travel Log {travelLogId} belongs to another user");
        }

        travelLogPlace = new TravelLogPlace()
        {
            TravelLogId = travelLogId,
            PlaceId = placeId
        };

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