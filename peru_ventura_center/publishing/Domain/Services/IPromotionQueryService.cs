using peru_ventura_center.publishing.Domain.Model.Queries;
using peru_ventura_center.Publishing.Domain.Model.Entities;

namespace peru_ventura_center.publishing.Domain.Services
{
    public interface IPromotionQueryService
    {
        Task<Promotion?> Handle(GetPromotionByIdQueryQuery query);
        Task<IEnumerable<Promotion>> Handle(GetAllPromotionsQuery query);
    }
}
