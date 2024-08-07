﻿using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Commands;

namespace peru_ventura_center.Payments.Domain.Services
{
    public interface IPaymentCommandServices
    {
        Task<Payment?> Handle(CreatePaymentCommand command);
    }
}
