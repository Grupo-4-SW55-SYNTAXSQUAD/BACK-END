using Microsoft.EntityFrameworkCore;
using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.profiles.Infrastructure.Persistence.EFC.Repositories
{
    public class OwnerRepository(AppDbContext context) : BaseRepository<Owner>(context), IOwnerReposirory
    {
        public new Task<Owner?> FindByIdAsync(int ownerId)
        {
            return Context.Set<Owner>()
                .Include(o => o.Promotion)
                .Include(o => o.Promotion.DestinationTrip)
                .Include(o => o.Promotion.DestinationTrip.Activity)
                .Include(o => o.Promotion.DestinationTrip.Activity.Category)
                .Include(o=>o.User)
                .Where(p => p.OwnerId == ownerId).FirstOrDefaultAsync();
        }
    }
}
