

using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Queries;

namespace peru_ventura_center.Payments.Domain.Services
{
    public interface IBookingStateQueryService
    {
        Task<IEnumerable<BookingState>> Handle(GetAllBookingStateQuery query);
        Task<BookingState?> Handle(GetBookingStateByIdQuery query);
    }
}
