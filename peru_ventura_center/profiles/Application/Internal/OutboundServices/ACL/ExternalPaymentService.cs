using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Infrastructure.Persistence.ACL;
using peru_ventura_center.profiles.Domain.Model.ValueObjects;

namespace peru_ventura_center.profiles.Application.Internal.OutboundServices.ACL
{
    public class ExternalPaymentService(IPaymentContextFacade paymentContextFacade)
    {
        public async Task<Booking?> FetchBookingById(int? booking_id)
        {
            var booking = await paymentContextFacade.FetchBookingById(booking_id);
            if (booking == null) return await Task.FromResult<Booking?>(null);
            return booking;
        }
        public async Task<BookingId?> CreateBooking(DateTime BookingDate, int ActivityId, int BookingStateId)
        {
            var bookingId = await paymentContextFacade.CreateBooking(BookingDate, ActivityId, BookingStateId);
            if (bookingId == 0) return await Task.FromResult<BookingId?>(null);
            return new BookingId(bookingId);
        }
    }
}
