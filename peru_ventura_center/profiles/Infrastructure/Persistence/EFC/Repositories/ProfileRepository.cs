using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.ValueObjects;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenterPlatform.Profiles.Infraestructure.Persistence.EFC.Repositories
{
    public class ProfileRepository(AppDbContext context) : BaseRepository<usuario>(context), IProfileRepository
    {
        public Task<usuario?> FindProfileByEmailAsync(EmailAddress email)
        {
            return Context.Set<usuario>().Where(p => p.CorreoElectronico==email).FirstOrDefaultAsync();
        }
    }
}
