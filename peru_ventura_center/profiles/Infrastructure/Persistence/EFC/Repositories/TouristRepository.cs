using Microsoft.EntityFrameworkCore;
using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.profiles.Infrastructure.Persistence.EFC.Repositories
{
    public class TouristRepository(AppDbContext context) : BaseRepository<Tourist>(context), ITouristRepository
    {
        public new Task<Tourist?> FindByIdAsync(int touristId)
        {
            return Context.Set<Tourist>()
                .Include(P=>P.Review)
                .Include(p=>p.Review.Activity)
                .Include(p => p.Review.Activity.Category)
                .Include(P => P.Booking)
                .Include(P => P.Booking.BookingState)
                .Include(P => P.User)
                .Where(p => p.TouristId == touristId).FirstOrDefaultAsync();
        }
    }
}
