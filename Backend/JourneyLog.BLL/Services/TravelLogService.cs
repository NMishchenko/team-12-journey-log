using AutoMapper;
using JourneyLog.BLL.Exceptions.BadRequestException;
using JourneyLog.BLL.Exceptions.NotFound;
using JourneyLog.BLL.Models.TravelLog;
using JourneyLog.BLL.Services.Interfaces;
using JourneyLog.DAL;
using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.BLL.Services;

public class TravelLogService : ITravelLogService
{
    private readonly ITravelLogRepository _travelLogRepository;
    private readonly IJourneyLogContext _journeyLogContext;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    
    public TravelLogService(ITravelLogRepository travelLogRepository,
        IJourneyLogContext journeyLogContext,
        ICurrentUserService currentUserService,
        IMapper mapper)
    {
        _travelLogRepository = travelLogRepository;
        _journeyLogContext = journeyLogContext;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }
    
    public async Task AddAsync(CreateTravelLogModel createTravelLogModel, CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        
        var travelLog = _mapper.Map<TravelLog>(createTravelLogModel);
        travelLog.CreationDate = DateTime.UtcNow;
        travelLog.UserId = currentUser.Id;

        await _travelLogRepository.AddAsync(travelLog);
        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid id, UpdateTravelLogModel updateTravelLogModel, CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var travelLog = await _travelLogRepository.GetByIdAsync(id);

        if (travelLog is null)
        {
            throw new NotFoundException($"Travel Log {id} not found");
        }

        if (travelLog.UserId != currentUser.Id)
        {
            throw new BadRequestException($"Travel Log {id} belongs to another user");
        }

        travelLog = _mapper.Map(updateTravelLogModel, travelLog);
        
        await _travelLogRepository.UpdateAsync(travelLog);
        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var travelLog = await _travelLogRepository.GetByIdAsync(id);

        if (travelLog is null)
        {
            throw new NotFoundException($"Travel Log {id} not found");
        }

        if (travelLog.UserId != currentUser.Id)
        {
            throw new BadRequestException($"Travel Log {id} belongs to another user");
        }

        await _travelLogRepository.DeleteByIdAsync(id);
        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<GetTravelLogModel> GetByIdAsync(Guid id)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var travelLog = await _travelLogRepository.GetWithAllNestedPropertiesAsync(id);

        if (travelLog is null)
        {
            throw new NotFoundException($"Travel Log {id} not found");
        }

        if (travelLog.UserId != currentUser.Id)
        {
            throw new BadRequestException($"Travel Log {id} belongs to another user");
        }

        return _mapper.Map<GetTravelLogModel>(travelLog);
    }
}