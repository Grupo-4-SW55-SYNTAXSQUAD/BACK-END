using peru_ventura_center.payments.Domain.Model.Aggregates;

namespace peru_ventura_center.payments.Infrastructure.Persistence.ACL
{
    public interface IBookingContextFacade
    {
        Task<int> CreateReservationStatus(string state);
        Task<Booking?> FetchReservationStatusById(int id);
    }
}
