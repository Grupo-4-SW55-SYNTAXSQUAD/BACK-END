using peru_ventura_center.Payments.Domain.Model.Aggregates;

namespace peru_ventura_center.Payments.Domain.Model.Queries
{
    public record GetPaymentStateByIdQuery(int PaymentStateId);
}
