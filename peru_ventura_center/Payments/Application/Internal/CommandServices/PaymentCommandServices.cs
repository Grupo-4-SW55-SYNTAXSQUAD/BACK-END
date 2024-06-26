using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Shared.Domain.Repositories;
using peru_ventura_center.Payments.Domain.Model.Commands;
using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Services;

namespace peru_ventura_center.Payments.Application.Internal.CommandServices
{
    public class PaymentCommandServices(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork ): IPaymentCommandServices
    {
            public async Task<Payment?> Handle(CreatePaymentCommand command)
            {
                var payment = new Payment(command.Amount, command.PaymentDate, command.PaymentTypeId, command.PaymentStateId,command.BookingId);
                await paymentRepository.AddAsync(payment);
                await unitOfWork.CompleteAsync();
                return payment;
            }
    }
}
