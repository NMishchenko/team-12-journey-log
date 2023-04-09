using JourneyLog.BLL.Exceptions.BadRequestException;
using JourneyLog.BLL.Exceptions.NotFound;
using JourneyLog.BLL.Models.TravelLogPlaceNotePhotos;
using JourneyLog.BLL.Services.Interfaces;
using JourneyLog.DAL;
using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.BLL.Services;

public class NotePhotoService : INotePhotoService
{
    private readonly INotePhotoRepository _notePhotoRepository;
    private readonly ITravelNoteRepository _travelNoteRepository;
    private readonly IJourneyLogContext _journeyLogContext;
    private readonly ICurrentUserService _currentUserService;
    private readonly IBlobStorageService _blobStorageService;
    
    public NotePhotoService(INotePhotoRepository notePhotoRepository,
        ITravelNoteRepository travelNoteRepository,
        IJourneyLogContext journeyLogContext,
        ICurrentUserService currentUserService,
        IBlobStorageService blobStorageService)
    {
        _notePhotoRepository = notePhotoRepository;
        _travelNoteRepository = travelNoteRepository;
        _journeyLogContext = journeyLogContext;
        _currentUserService = currentUserService;
        _blobStorageService = blobStorageService;
    }
    
    public async Task CreateAsync(Guid noteId, CreateNotePhotoModel createNotePhotoModel, CancellationToken cancellationToken)
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
        
        var imageFileName = await _blobStorageService.CreateImageAsyncAndGetFileName(createNotePhotoModel.ImageBase64);

        var notePhoto = new NotePhoto() { TravelNoteId = travelNote.Id, FileName = imageFileName };
        
        await _notePhotoRepository.AddAsync(notePhoto);
        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid photoId, CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var notePhoto = await _notePhotoRepository.GetByIdWithTravelLogAsync(photoId);

        if (notePhoto is null)
        {
            throw new NotFoundException($"Note photo with id {notePhoto} not found");
        }
        
        if (notePhoto.TravelNote.TravelLogPlace.TravelLog.UserId != currentUser.Id)
        {
            throw new BadRequestException($"Travel Log {notePhoto.TravelNote.TravelLogPlace.TravelLogId} belongs to another user");
        }

        await _blobStorageService.DeleteImageAsync(notePhoto.FileName);

        await _notePhotoRepository.DeleteByIdAsync(photoId);
        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }
}