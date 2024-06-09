namespace peru_ventura_center.Publishing.Interfaces.REST.Resources
{
    public record DestinationTripResource(
        int DestinationTripId,
        string Name, 
        string Description, 
        string Location, 
        ActivityResource Activity
        );

}
