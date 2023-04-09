using JourneyLog.BLL.Models.Place;
using JourneyLog.BLL.Services.Interfaces;
using JourneyLog.DAL;
using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.BLL.Services;

public class UserPlaceService : IUserPlaceService
{
    private readonly IUserPlaceRepository _userPlaceRepository;
    private readonly IJourneyLogContext _journeyLogContext;
    private readonly ICurrentUserService _currentUserService;

    public UserPlaceService(IUserPlaceRepository userPlaceRepository,
        IJourneyLogContext journeyLogContext,
        ICurrentUserService currentUserService)
    {
        _userPlaceRepository = userPlaceRepository;
        _journeyLogContext = journeyLogContext;
        _currentUserService = currentUserService;
    }
    
    public async Task UpsertRatingAsync(string xid, CreateUpdatePlaceRating createUpdatePlaceRating, CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var userPlace = await _userPlaceRepository.GetByUserIdAndPlaceIdAsync(currentUser.Id, xid);

        if (userPlace is null)
        {
            userPlace = new UserPlace()
            {
                UserId = currentUser.Id,
                PlaceId = xid,
                Rate = createUpdatePlaceRating.Rating
            };
            await _userPlaceRepository.AddAsync(userPlace);
        }
        else
        {
            userPlace.Rate = createUpdatePlaceRating.Rating;
            await _userPlaceRepository.UpdateAsync(userPlace);
        }

        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpsertReviewAsync(string xid, CreateUpdatePlaceReview createUpdatePlaceReview, CancellationToken cancellationToken)
    {
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        var userPlace = await _userPlaceRepository.GetByUserIdAndPlaceIdAsync(currentUser.Id, xid);

        if (userPlace is null)
        {
            userPlace = new UserPlace()
            {
                UserId = currentUser.Id,
                PlaceId = xid,
                Review = createUpdatePlaceReview.Review
            };
            await _userPlaceRepository.AddAsync(userPlace);
        }
        else
        {
            userPlace.Review = createUpdatePlaceReview.Review;
            await _userPlaceRepository.UpdateAsync(userPlace);
        }

        await _journeyLogContext.SaveChangesAsync(cancellationToken);
    }
}