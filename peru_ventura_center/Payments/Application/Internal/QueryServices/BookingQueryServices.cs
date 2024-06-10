using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Queries;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Payments.Domain.Services;

namespace peru_ventura_center.Payments.Application.Internal.QueryServices
{
    public class BookingQueryServices(IBookingRepository bookingRepository): IBookingQueryServices
    {
        public async Task<Booking?> Handle(GetBookingByIdQuery query)
        {
            return await bookingRepository.FindByIdAsync(query.BookingId);
        }
        public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query)
        {
            return await bookingRepository.ListAsync();
        }
    }
}
