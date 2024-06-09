using Microsoft.EntityFrameworkCore;
using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.payments.Infrastructure.Persistence.EFC.Repositories
{
    public class BookingRepository(AppDbContext context) : BaseRepository<Booking>(context), IBookingRepository
    {
        public Task<Booking?> FindProfileByIdAsync(int id)
        {
            return Context.Set<Booking>().Where(p => p.booking_state_id == id).FirstOrDefaultAsync();
        }
    }
}
