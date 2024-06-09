using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.payments.Domain.Repositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Task<Booking?> FindProfileByIdAsync(int id);

    }
}
