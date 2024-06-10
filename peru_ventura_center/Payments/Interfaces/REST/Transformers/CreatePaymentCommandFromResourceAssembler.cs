using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Commands;
using peru_ventura_center.Payments.Interfaces.REST.Resources;

namespace peru_ventura_center.Payments.Interfaces.REST.Transformers
{
    public class CreatePaymentCommandFromResourceAssembler
    {
        public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
        {
            return new CreatePaymentCommand(
                resource.Amount,
                resource.PaymentDate,
                resource.PaymentTypeId,
                resource.PaymentStateId
                );
        }
        
    };
}
