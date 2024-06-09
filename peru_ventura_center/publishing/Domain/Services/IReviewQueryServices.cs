using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Domain.Model.Queries;

namespace peru_ventura_center.Publishing.Domain.Services
{
    public interface IReviewQueryServices
    {
        Task<Review?> Handle(GetReviewById query);
        Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query);
    }
}
