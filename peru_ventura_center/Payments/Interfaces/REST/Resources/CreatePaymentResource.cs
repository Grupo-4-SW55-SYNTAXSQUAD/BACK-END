﻿
namespace peru_ventura_center.Payments.Interfaces.REST.Resources
{
    public record CreatePaymentResource
    ( 
        float Amount,
        DateTime PaymentDate,
        int  PaymentTypeId,
        int PaymentStateId,
        int BookingId
    );
}
