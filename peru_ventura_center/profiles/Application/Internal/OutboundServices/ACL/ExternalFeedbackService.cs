using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Infrastructure.Persistence.ACL;
using peru_ventura_center.profiles.Domain.Model.ValueObjects;

namespace peru_ventura_center.profiles.Application.Internal.OutboundServices.ACL
{
    public class ExternalFeedbackService(IFeedBackContextFacade feedBackContextFacade)
    {
        public async Task<Activity?> FetchActivityById(int ActivityId)
        {
            var activity = await feedBackContextFacade.FetchActivityById(ActivityId);
            if (activity == null) return await Task.FromResult<Activity?>(null);
            return activity;
        }   
        public async Task<ActivityId?> CreateActivity(string Name, string Description, string Schedule, int MaxPeople, decimal Cost, int CategoryId)
        {
            var activityId = await feedBackContextFacade.CreateActivity(Name,Description,Schedule, MaxPeople, Cost,CategoryId);
            if (activityId == 0) return await Task.FromResult<ActivityId?>(null);
            return new ActivityId(activityId);
        }

        public async Task<Review?> FetchReviewById(int ReviewId)
        {
            var review = await feedBackContextFacade.FetchReviewById(ReviewId);
            if (review == null) return await Task.FromResult<Review?>(null);
            return review;
        }
        public async Task<ReviewId?> CreateReview(int Score, string Comment, int ActivityId)
        {
            var reviewId = await feedBackContextFacade.CreateReview(Score, Comment, ActivityId);
            if (reviewId == 0) return await Task.FromResult<ReviewId?>(null);
            return new ReviewId(reviewId);
        }

    }
}
