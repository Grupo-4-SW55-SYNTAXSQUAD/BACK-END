using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Interfaces.REST.Resources;


namespace peru_ventura_center.Payments.Interfaces.REST.Transformers
{
    public class PaymentResourceFromEntityAssembler
    {
        public static PaymentResource ToResourceFromEntity(Payment payment)
        {
            return new PaymentResource(
                    payment.PaymentId,
                    payment.Amount,
                    payment.PaymentDate,
                    PaymentTypeResourceFromEntityAssembler.ToResourceFromEntity(payment.PaymentType),
                    PaymentStateResourceFromEntityAssembler.ToResourceFromEntity(payment.PaymentState),
                    BookingResourceFromEntityAssembler.ToResourceFromEntity(payment.Booking)

                );
        }
    }
}
