using peru_ventura_center.publishing.Domain.Model.Aggregates;
using peru_ventura_center.publishing.Domain.Model.Queries;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.publishing.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace peru_ventura_center.publishing.Application.Internal.QueryServices
{
    public class PromotionQueryService(IPromotionRepository promotionRepository):IPromotionQueryService
    {
        public async Task<promociones?> Handle(GetPromotionByIdQuery query)
        {
            return await promotionRepository.FindByIdAsync(query.PromotionId);
        }
        public async Task<IEnumerable<promociones>> Handle(GetAllPromotionsQuery query)
        {
            return await promotionRepository.ListAsync();
        }
    }
}
