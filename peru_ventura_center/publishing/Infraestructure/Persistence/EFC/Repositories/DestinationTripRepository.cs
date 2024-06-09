using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.Publishing.Infraestructure.Persistence.EFC.Repositories
{
    public class DestinationTripRepository(AppDbContext context) : BaseRepository<DestinationTrip>(context), IDestinationTripRepository
    {
        public new async Task<DestinationTrip?> FindByIdAsync(int DestinationTripId) => await Context.Set<DestinationTrip>()
            .Include(a => a.Activity)
            .Include(a=> a.Activity.Category)
            .Where(a => a.DestinationTripId == DestinationTripId).FirstOrDefaultAsync();
        public new async Task<IEnumerable<DestinationTrip>> ListAsync() => await Context.Set<DestinationTrip>()
            .Include(a => a.Activity)
            .Include(a => a.Activity.Category)
            .ToListAsync();
    }
}
