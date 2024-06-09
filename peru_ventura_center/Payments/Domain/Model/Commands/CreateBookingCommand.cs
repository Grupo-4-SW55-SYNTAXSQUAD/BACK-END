namespace peru_ventura_center.Payments.Domain.Model.Commands
{
    public record CreateBookingCommand(
        DateTime BookingDate,
        int ActivityId,
        int BookingStateId
    );
}
