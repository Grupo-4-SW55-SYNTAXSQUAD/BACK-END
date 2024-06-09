using peru_ventura_center.Publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.publishing.Interfaces.REST.Resources
{
    public record PromotionResource(
        int PromotionId,
        DestinationTripResource DestinationTrip,
        string Name,
        string Description,
        string Offer
       );
  
}
