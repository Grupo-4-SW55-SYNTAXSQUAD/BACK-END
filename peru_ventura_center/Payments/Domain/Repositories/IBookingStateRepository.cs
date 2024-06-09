using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.Payments.Domain.Repositories
{
    public interface IBookingStateRepository : IBaseRepository<BookingState>
    {
        Task<BookingState?> FindBookingByIdAsync(int booking_state_id);

    }
}
