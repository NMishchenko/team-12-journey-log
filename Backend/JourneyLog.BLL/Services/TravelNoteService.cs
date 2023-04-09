﻿using JourneyLog.BLL.Exceptions.BadRequestException;
using JourneyLog.BLL.Exceptions.NotFound;
using JourneyLog.BLL.Models.TravelLogPlaceNote;
using JourneyLog.BLL.Services.Interfaces;
using JourneyLog.DAL;
using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.BLL.Services;

public class TravelNoteService : ITravelNoteService
{
    private readonly ITravelNoteRepository _travelNoteRepository;
    private readonly IJourneyLogContext _journeyLogContext;
    private readonly ICurrentUserService _currentUserService;
    
    public TravelNoteService(ITravelNoteRepository travelNoteRepository,
        IJourneyLogContext journeyLogContext,
        ICurrentUserService currentUserService)
    {
        _travelNoteRepository = travelNoteRepository;
        _journeyLogContext = journeyLogContext;
        _currentUserService = currentUserService;
    }
    
    public async Task UpsertAsync(Guid travelLogId, string placeId, CreateUpdateNoteModel createUpdateNoteModel,
        CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var travelNote = await _travelNoteRepository.GetByTravelLogIdAndPlaceIdWithTravelLogAsync(travelLogId, placeId);

        if (travelNote is null)
        {
            travelNote = new TravelNote()
            {
                TravelLogPlaceId = travelLogId,
                Text = createUpdateNoteModel.Text
            };
            await _travelNoteRepository.AddAsync(travelNote);
        }
        else
        {
            if (travelNote.TravelLogPlace.TravelLog.UserId != currentUser.Id)
            {
                throw new BadRequestException($"Travel Log {travelLogId} belongs to another user");
            }
            
            travelNote.Text = createUpdateNoteModel.Text;
            await _travelNoteRepository.UpdateAsync(travelNote);
        }

        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid noteId, CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var travelNote = await _travelNoteRepository.GetByIdWithTravelLogAsync(noteId);

        if (travelNote is null)
        {
            throw new NotFoundException($"Travel note with id {noteId} not found");
        }
        
        if (travelNote.TravelLogPlace.TravelLog.UserId != currentUser.Id)
        {
            throw new BadRequestException($"Travel Log {travelNote.TravelLogPlace.TravelLogId} belongs to another user");
        }
        
        await _travelNoteRepository.DeleteByIdAsync(noteId);
        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }
}