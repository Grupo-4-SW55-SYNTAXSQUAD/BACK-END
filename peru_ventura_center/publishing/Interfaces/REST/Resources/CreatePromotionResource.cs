
namespace peru_ventura_center.publishing.Interfaces.REST.Resources
{
    public record CreatePromotionResource(
        int DestinationTripId,
        string Name,
        string Description,
        string Offer
        );

}
