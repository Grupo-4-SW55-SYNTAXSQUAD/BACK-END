namespace peru_ventura_center.Payments.Interfaces.REST.Resources
{
    public record CreateBookingResource (
        DateTime BookingDate,
        int ActivityId,
        int BookingStateId
    );
}
