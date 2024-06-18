using peru_ventura_center.Publishing.Domain.Model.Entities;

namespace peru_ventura_center.Publishing.Infrastructure.Persistence.ACL
{
    public interface IPublishingContextFacade
    {
        Task<int> CreatePromotion(int DestinationTripId,
        string Name,
        string Description,
        string Offer);
        Task<Promotion?> FetchPromotionById(int PromotionId);
    }
}
