using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Queries;

namespace peru_ventura_center.Payments.Domain.Services
{
    public interface IPaymentStateQueryServices
    {
        Task<PaymentState?> Handle(GetPaymentStateByIdQuery query);
        Task<IEnumerable<PaymentState>> Handle(GetAllPaymentStateQuery query);
    }
}
