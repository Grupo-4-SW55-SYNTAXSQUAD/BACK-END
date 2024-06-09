using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Queries;
using peru_ventura_center.payments.Domain.Repositories;
using peru_ventura_center.payments.Domain.Services;

namespace peru_ventura_center.payments.Application.Internal.QueryServices
{
    public class BookingQueryService(IBookingRepository reservationStatus) : IBookingQueryService
    {
        public async Task<IEnumerable<Booking>> Handle(GetAllBookingQuery query)
        {
            return await reservationStatus.ListAsync();
        }

        public async Task<Booking?> Handle(GetBookingByIdQuery query)
        {
            return await reservationStatus.FindByIdAsync(query.id);
        }
    }
}
