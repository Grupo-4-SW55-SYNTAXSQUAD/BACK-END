using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Model.Queries;

namespace peru_ventura_center.Feedback.Domain.Services
{
    public interface IReviewQueryServices
    {
        Task<Review?> Handle(GetReviewById query);
        Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query);
    }
}
