using peru_ventura_center.payments.Domain.Model.Aggregates;

namespace peru_ventura_center.payments.Infrastructure.Persistence.ACL
{
    public interface IBookingStateContextFacade
    {
        Task<int> CreateReservationStatus(string state, int booking_states_pk);
        Task<BookingState?> FetchReservationStatusById(int id);
    }
}
