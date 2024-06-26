using peru_ventura_center.Payments.Domain.Model.Aggregates;

namespace peru_ventura_center.Payments.Infrastructure.Persistence.ACL
{
    public interface IPaymentContextFacade
    {
        Task<int> CreateBooking(DateTime BookingDate, int ActivityId, int BookingStateId);
        Task<Booking?> FetchBookingById(int? booking_id);
    }
}
