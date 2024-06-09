using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.Payments.Infrastructure.Persistence.EFC.Repositories
{
    public class BookingStateRepository(AppDbContext context) : BaseRepository<BookingState>(context), IBookingStateRepository
    {
        public Task<BookingState?> FindBookingByIdAsync(int booking_state_id)
        {
            return Context.Set<BookingState>().Where(p => p.booking_state_id == booking_state_id).FirstOrDefaultAsync();
        }
    }
}
