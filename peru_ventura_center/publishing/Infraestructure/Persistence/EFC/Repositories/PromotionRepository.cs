using peru_ventura_center.publishing.Domain.Model.Aggregates;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace peru_ventura_center.publishing.Infraestructure.Persistence.EFC.Repositories
{
    public class PromotionRepository(AppDbContext context):BaseRepository<promociones>(context),IPromotionRepository
    {
        public new async Task<promociones?> FindByIdAsync(int PromocionId) => await Context.Set<promociones>().Include(t => t.PromocionId).Where(t => t.TallerId == PromocionId).FirstOrDefaultAsync();

        public new async Task<IEnumerable<promociones>> ListAsync() => await Context.Set<promociones>()
                .Include(p => p.Comunidad)
                .Include(p => p.Taller)
                .ToListAsync();
    }
}
