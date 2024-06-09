

using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Queries;

namespace peru_ventura_center.payments.Domain.Services
{
    public interface IBookingQueryService
    {
        Task<IEnumerable<Booking>> Handle(GetAllBookingQuery query);
        Task<Booking?> Handle(GetBookingByIdQuery query);
    }
}
