using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Domain.Model.Queries;
using peru_ventura_center.Publishing.Domain.Repositories;
using peru_ventura_center.Publishing.Domain.Services;

namespace peru_ventura_center.Publishing.Application.Internal.QueryServices
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
