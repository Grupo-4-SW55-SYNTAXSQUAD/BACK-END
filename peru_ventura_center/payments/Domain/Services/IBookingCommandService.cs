using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Commands;

namespace peru_ventura_center.payments.Domain.Services
{
    public interface IBookingCommandService
    {
        Task<Booking?> Handle(CreateBookingCommand command);
    }
}
