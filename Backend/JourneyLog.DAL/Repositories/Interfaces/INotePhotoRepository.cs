﻿using JourneyLog.DAL.Entities;

namespace JourneyLog.DAL.Repositories.Interfaces;

public interface INotePhotoRepository : IRepository<Guid, NotePhoto>
{
    Task<NotePhoto?> GetByIdWithTravelLogAsync(Guid id);
}