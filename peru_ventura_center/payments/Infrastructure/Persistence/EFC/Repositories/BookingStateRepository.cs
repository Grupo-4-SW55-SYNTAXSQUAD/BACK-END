using Microsoft.EntityFrameworkCore;
using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.payments.Infrastructure.Persistence.EFC.Repositories
{
    public class BookingStateRepository(AppDbContext context) : BaseRepository<BookingState>(context), IBookingStateRepository
    {
        public Task<BookingState?> FindProfileByIdAsync(int id)
        {
            return Context.Set<BookingState>().Where(p => p.booking_state_id == id).FirstOrDefaultAsync();
        }
    }
}
