using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Queries;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Payments.Domain.Services;

namespace peru_ventura_center.Payments.Application.Internal.QueryServices
{
    public class PaymentQueryServices(IPaymentRepository paymentRepository) : IPaymentQueryServices
    {
        public async Task<Payment?> Handle(GetPaymentByIdQuery query)
        {
            return await paymentRepository.FindByIdAsync(query.PaymentId);
        }

        public async Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery query)
        {
            return await paymentRepository.ListAsync();
        }
    }
}
