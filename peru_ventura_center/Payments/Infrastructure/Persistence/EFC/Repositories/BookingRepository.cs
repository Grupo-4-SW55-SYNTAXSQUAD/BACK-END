using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.Payments.Infrastructure.Persistence.EFC.Repositories
{
    public class BookingRepository(AppDbContext context): BaseRepository<Booking>(context), IBookingRepository
    {
        public new async Task<Booking?> FindByIdAsync(int bookingId) => await Context.Set<Booking>()
            .Include(a => a.BookingState)
            .Where(a => a.BookingId == bookingId).FirstOrDefaultAsync();

        public new async Task<IEnumerable<Booking>> ListAsync() => await Context.Set<Booking>()
            .Include(a => a.BookingState)
            .ToListAsync();
    }
}
