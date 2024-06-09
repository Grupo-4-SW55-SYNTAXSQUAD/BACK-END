using peru_ventura_center.publishing.Interfaces.REST.Resources;
using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Interfaces.REST.Transformers;

namespace peru_ventura_center.publishing.Interfaces.REST.Transformers
{
    public static class PromotionResourceFromEntityAssembler
    {
        public static PromotionResource ToResourceFromEntity (Promotion promotion)
        {
            return new PromotionResource(
                promotion.PromotionId,
                DestinationTripResourceFromEntityAssembler.ToResourceFromEntity(promotion.DestinationTrip),
                promotion.Name,
                promotion.Description,
                promotion.Offer
                );
        }
    }
}
