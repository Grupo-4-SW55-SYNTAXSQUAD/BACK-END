namespace peru_ventura_center.publishing.Domain.Model.Commands
{
    public record CreatePromotionCommand(
        int DestinationTripId, 
        string Name, 
        string Description, 
        string Offer
        );

}
