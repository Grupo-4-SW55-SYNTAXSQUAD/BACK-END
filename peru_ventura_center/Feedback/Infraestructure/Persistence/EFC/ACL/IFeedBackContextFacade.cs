

using peru_ventura_center.Feedback.Domain.Model.Aggregates;

namespace peru_ventura_center.Feedback.Infrastructure.Persistence.ACL
{
    public interface IFeedBackContextFacade
    {
        Task<int> CreateActivity(string Name, string Description, string Schedule, int MaxPeople, decimal Cost, int CategoryId);
        Task<Activity?> FetchActivityById(int ActivityId);

        Task<Review?> FetchReviewById(int? ReviewId);
        Task<int> CreateReview(int Score, string Comment, int ActivityId);

        Task<Category?> FetchCategoryById(int CategoryId);
    }
}
