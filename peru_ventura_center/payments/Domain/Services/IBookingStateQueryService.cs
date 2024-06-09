

using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Queries;

namespace peru_ventura_center.payments.Domain.Services
{
    public interface IBookingStateQueryService
    {
        Task<IEnumerable<BookingState>> Handle(GetAllBookingStateQuery query);
        Task<BookingState?> Handle(GetBookingStateByIdQuery query);
    }
}
