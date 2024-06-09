using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Queries;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Payments.Domain.Services;

namespace peru_ventura_center.Payments.Application.Internal.QueryServices
{
    public class PaymentTypeQueryServices(IPaymentTypeRepository paymentTypeRepository): IPaymentTypeQueryServices
    {
        public async Task<PaymentType?> Handle(GetPaymentTypeByIdQuery query)
        {
            return await paymentTypeRepository.FindByIdAsync(query.PaymentTypeId);
        }

        public async Task<IEnumerable<PaymentType>> Handle(GetAllPaymentTypeQuery query)
        {
            return await paymentTypeRepository.ListAsync();
        }
    }
}
