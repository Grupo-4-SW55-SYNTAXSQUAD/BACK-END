using peru_ventura_center.payments.Domain.Model.Aggregates;

namespace peru_ventura_center.payments.Infrastructure.Persistence.ACL
{
    public interface IBookingStateContextFacade
    {
        Task<int> CreateBooking(string state);
        Task<BookingState?> FetchBookingById(int booking_state_id);
    }
}
