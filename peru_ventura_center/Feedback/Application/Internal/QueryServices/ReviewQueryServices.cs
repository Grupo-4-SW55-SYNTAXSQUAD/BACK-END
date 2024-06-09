using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Model.Queries;
using peru_ventura_center.Feedback.Domain.Repositories;
using peru_ventura_center.Feedback.Domain.Services;

namespace peru_ventura_center.Feedback.Application.Internal.QueryServices
{
    public class ReviewQueryServices(IReviewRepository reviewRepository) : IReviewQueryServices
    {
        public async Task<Review?> Handle(GetReviewById query)
        {
            return await reviewRepository.FindByIdAsync(query.ReviewId);
        }

        public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query)
        {
            return await reviewRepository.ListAsync();
        }
    }
}
