using peru_ventura_center.profiles.Domain.Model.ValueObjects;
using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Infrastructure.Persistence.ACL;

namespace peru_ventura_center.profiles.Application.Internal.OutboundServices.ACL
{
    public class ExternalPublishingService(IPublishingContextFacade promotionContextFacade)
    {

        public async Task<Promotion?> FetchPromotionById(int? PromotionId)
        {
            var promotion = await promotionContextFacade.FetchPromotionById(PromotionId);
            if (promotion == null) return await Task.FromResult<Promotion?>(null);
            return promotion;
        }   
        public async Task<PromotionId?> CreatePromotion(int DestinationTripId,string Name,string Description,string Offer)
        {
            var promotionId = await promotionContextFacade.CreatePromotion(DestinationTripId, Name, Description, Offer);
            if (promotionId == 0) return await Task.FromResult<PromotionId?>(null);
            return new PromotionId(promotionId);
        }

    
    }
}
