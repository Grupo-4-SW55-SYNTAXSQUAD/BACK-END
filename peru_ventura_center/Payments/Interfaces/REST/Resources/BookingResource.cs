namespace peru_ventura_center.Payments.Interfaces.REST.Resources
{
    public record BookingResource(
        int BookingId,
        DateTime BookingDate,
        int ActivityId,
        int BookingStateId
    );
}
