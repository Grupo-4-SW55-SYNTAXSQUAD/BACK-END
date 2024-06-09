using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Interfaces.REST.Resources;

namespace peru_ventura_center.Payments.Interfaces.REST.Transformers
{
    public class PaymentStateResourceFromEntityAssembler
    {
        public static PaymentStateResource ToResourceFromEntity(PaymentState paymentState)
        {
            return new PaymentStateResource(paymentState.PaymentStateId, paymentState.State);
        }
    }
}
