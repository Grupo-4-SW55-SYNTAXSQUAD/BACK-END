using peru_ventura_center.publishing.Domain.Model.Queries;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.Publishing.Domain.Model.Entities;

namespace peru_ventura_center.publishing.Application.Internal.QueryServices
{
    public class PromotionQueryService(IPromotionRepository promotionRepository):IPromotionQueryService
    {
        public async Task<Promotion?> Handle(GetPromotionByIdQueryQuery query)
        {
            return await promotionRepository.FindByIdAsync(query.PromotionId);
        }
        public async Task<IEnumerable<Promotion>> Handle(GetAllPromotionsQuery query)
        {
            return await promotionRepository.ListAsync();
        }
    }
}
