using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Queries;

namespace peru_ventura_center.Payments.Domain.Services
{
    public interface IPaymentTypeQueryServices
    {
        Task<PaymentType?> Handle(GetPaymentTypeByIdQuery query);
        Task<IEnumerable<PaymentType>> Handle(GetAllPaymentTypeQuery query);
    }
}
