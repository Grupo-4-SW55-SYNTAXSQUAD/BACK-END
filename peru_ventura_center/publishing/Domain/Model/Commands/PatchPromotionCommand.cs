namespace peru_ventura_center.Publishing.Domain.Model.Commands
{
    public record PatchPromotionCommand(int DestinationTripId, string name);
}
