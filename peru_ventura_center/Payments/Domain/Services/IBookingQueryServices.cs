using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Queries;

namespace peru_ventura_center.Payments.Domain.Services
{
    public interface IBookingQueryServices
    {
        Task<Booking?> Handle(GetBookingByIdQuery query);
        Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query);
    }
}
