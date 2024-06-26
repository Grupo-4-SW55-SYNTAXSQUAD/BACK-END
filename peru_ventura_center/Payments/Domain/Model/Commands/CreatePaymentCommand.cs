using Microsoft.AspNetCore.Mvc.ViewFeatures;
using peru_ventura_center.Payments.Domain.Model.Aggregates;

namespace peru_ventura_center.Payments.Domain.Model.Commands
{
    public record CreatePaymentCommand
    ( 
        float Amount,
        DateTime PaymentDate,
        int  PaymentTypeId,
        int  PaymentStateId,
        int  BookingId
    );
}
