using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Publishing.Domain.Model.Entities;

namespace peru_ventura_center.publishing.Infraestructure.Persistence.EFC.Repositories
{
    public class PromotionRepository(AppDbContext context):BaseRepository<Promotion>(context),IPromotionRepository
    {
        public new async Task<Promotion?> FindByIdAsync(int PromotionId) => await Context.Set<Promotion>()
            .Include(p => p.DestinationTrip)
            .Include(p => p.DestinationTrip.Activity)
            .Include(p => p.DestinationTrip.Activity.Category)
            .Where(p => p.PromotionId == PromotionId).FirstOrDefaultAsync();
        
        public new async Task<IEnumerable<Promotion>> ListAsync() => await Context.Set<Promotion>()
                .Include(p => p.DestinationTrip)
                .Include(p => p.DestinationTrip.Activity)
                .Include(p => p.DestinationTrip.Activity.Category)
                .ToListAsync();


        
    }
}
