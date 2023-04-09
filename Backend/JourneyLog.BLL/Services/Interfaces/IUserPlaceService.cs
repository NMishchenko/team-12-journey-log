using JourneyLog.BLL.Models.Place;

namespace JourneyLog.BLL.Services.Interfaces;

public interface IUserPlaceService
{
    Task UpsertRatingAsync(string xid, CreateUpdatePlaceRating createUpdatePlaceRating, CancellationToken cancellationToken);
    Task UpsertReviewAsync(string xid, CreateUpdatePlaceReview createUpdatePlaceReview, CancellationToken cancellationToken);
}