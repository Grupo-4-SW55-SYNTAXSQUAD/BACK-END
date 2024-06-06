using Microsoft.EntityFrameworkCore;
using peru_ventura_center.publishing.Domain.Model.Entities;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.publishing.Infraestructure.Persistence.EFC.Repositories
{
    public class TallerRepository(AppDbContext context) : BaseRepository<Taller>(context), ITallerRepository
    {
        public new async Task<Taller?> FindByIdAsync(int ComunidadId) => await Context.Set<Taller>().Where(t => t.TallerId == ComunidadId).FirstOrDefaultAsync();
    }
}
