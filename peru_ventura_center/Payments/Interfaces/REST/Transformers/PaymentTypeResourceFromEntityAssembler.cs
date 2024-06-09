using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Interfaces.REST.Resources;

namespace peru_ventura_center.Payments.Interfaces.REST.Transformers
{
    public class PaymentTypeResourceFromEntityAssembler
    {
        public static PaymentTypeResource ToResourceFromEntity(PaymentType paymentType)
        {
            return new PaymentTypeResource(paymentType.PaymentTypeId, paymentType.Type);
        }
    }
}
