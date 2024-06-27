using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Model.Commands;
using peru_ventura_center.Feedback.Domain.Model.Queries;
using peru_ventura_center.Feedback.Domain.Services;

namespace peru_ventura_center.Feedback.Infrastructure.Persistence.ACL.Services
{
    public class FeedbackContextFacade(IActivityCommandServices activityCommandServices, IActivityQueryServices activityQueryServices,IReviewCommandServices reviewCommandServices, IReviewQueryServices reviewQueryServices, ICategoryQueryService categoryQueryService) : IFeedBackContextFacade
    {
        public async Task<int> CreateActivity(string Name, string Description, string Schedule, int MaxPeople, decimal Cost, int CategoryId)
        {
            var createActivityCommand = new CreateActivityCommand( Name,  Description,  Schedule,  MaxPeople,  Cost,  CategoryId);

            var activity = await activityCommandServices.Handle(createActivityCommand);

            return activity?.ActivityId ?? 0;
        }

        public async Task<Activity?> FetchActivityById(int ActivityId)
        {
            var getActivityById= new GetActivityByIdQuery(ActivityId);
            var activity = await activityQueryServices.Handle(getActivityById);
            return activity;
        }
 
        public async Task<Review?> FetchReviewById(int ReviewId)
        {
            var getReviewById = new GetReviewByIdQuery(ReviewId);
            var review = await reviewQueryServices.Handle(getReviewById);
            return review;
        }
        public async Task<int> CreateReview(int Score, string Comment, int ActivityId)
        {
            var createReviewCommand = new CreateReviewCommand(Score, Comment, ActivityId);
            var review = await reviewCommandServices.Handle(createReviewCommand);
            return review?.ReviewId ?? 0;
        }

        public async Task<Category?> FetchCategoryById(int CategoryId)
        {
            var getCategoryById = new GetCategoryByIdQuery(CategoryId);
            var category = await categoryQueryService.Handle(getCategoryById);
            return category;
        }

        public Task<Review?> FetchReviewById(int? ReviewId)
        {
            throw new NotImplementedException();
        }
    }
}
