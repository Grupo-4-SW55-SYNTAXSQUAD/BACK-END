namespace peru_ventura_center.Payments.Interfaces.REST.Resources
{
    public record PaymentResource(
        int PaymentId,
        float Amount,
        DateTime PaymentDate,
        PaymentTypeResource PaymentType,
        PaymentStateResource PaymentState,
        BookingResource Booking
    );
}
