using peru_ventura_center.publishing.Domain.Model.Aggregates;
using peru_ventura_center.publishing.Domain.Model.Queries;

namespace peru_ventura_center.publishing.Domain.Services
{
    public interface IPromotionQueryService
    {
        Task<promociones?> Handle(GetPromotionByIdQuery query);
        Task<IEnumerable<promociones>> Handle(GetAllPromotionsQuery query);
    }
}
