using peru_ventura_center.payments.Domain.Model.Aggregates;

namespace peru_ventura_center.payments.Infrastructure.Persistence.ACL
{
    public interface IBookingContextFacade
    {
        Task<int> CreateBooking(string state);
        Task<Booking?> FetchBookingById(int booking_id);
    }
}
