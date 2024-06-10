using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Queries;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Payments.Domain.Services;

namespace peru_ventura_center.Payments.Application.Internal.QueryServices
{
    public class PaymentStateQueryServices(IPaymentStateRepository paymentStateRepository) : IPaymentStateQueryServices
    {  
        public async Task<PaymentState?> Handle(GetPaymentStateByIdQuery query)
        {
            return await paymentStateRepository.FindByIdAsync(query.PaymentStateId);
        }
        public async Task<IEnumerable<PaymentState>> Handle(GetAllPaymentStateQuery query)
        {
            return await paymentStateRepository.ListAsync();
        }
            
    }
   
}
