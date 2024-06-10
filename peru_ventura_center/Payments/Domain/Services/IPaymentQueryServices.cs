using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Queries;

namespace peru_ventura_center.Payments.Domain.Services
{
    public interface IPaymentQueryServices
    {
        Task<Payment?> Handle(GetPaymentByIdQuery query);
        Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery query);
    }
}
