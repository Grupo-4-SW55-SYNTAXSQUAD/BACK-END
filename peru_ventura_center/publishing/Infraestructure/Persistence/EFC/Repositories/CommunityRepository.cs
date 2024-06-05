using peru_ventura_center.publishing.Domain.Model.Entities;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace peru_ventura_center.publishing.Infraestructure.Persistence.EFC.Repositories
{
    public class CommunityRepository(AppDbContext context):BaseRepository<comunidad>(context),ICommunityRepository
    {
        public new async Task<comunidad?> FindByIdAsync(int ComunidadId) => await Context.Set<comunidad>().Include(t => t.ComunidadId).Where(t => t.ComunidadId == ComunidadId).FirstOrDefaultAsync();

        public new async Task<IEnumerable<comunidad>> ListAsync() => await Context.Set<comunidad>().ToListAsync();
    }
}
