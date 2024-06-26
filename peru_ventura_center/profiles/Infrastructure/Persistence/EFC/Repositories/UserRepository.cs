using peru_ventura_center.profiles.Domain.Model.ValueObjects;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using peru_ventura_center.profiles.Domain.Model.Entities;

namespace LearningCenterPlatform.Profiles.Infraestructure.Persistence.EFC.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public Task<User?> FindProfileByEmailAsync(string email)
        {
            return Context.Set<User>().Where(p => p.email==email).FirstOrDefaultAsync();
        }
        public new Task<User?> FindByIdAsync(int userId)
        {
            return Context.Set<User>().Where(p => p.UserId == userId).FirstOrDefaultAsync();
        }
        public new async Task<IEnumerable<User>> ListAsync() => await Context.Set<User>().ToListAsync();
        public async Task DeleteProfileAsync(User user)
        {
            Context.Entry(user).State = EntityState.Deleted;

            // Delete associated Owner if exists
            var owner = await Context.Set<Owner>().FirstOrDefaultAsync(o => o.UserId == user.UserId);
            if (owner != null)
            {
                Context.Set<Owner>().Remove(owner);
            }

            // Delete associated Tourist if exists
            var tourist = await Context.Set<Tourist>().FirstOrDefaultAsync(t => t.UserId == user.UserId);
            if (tourist != null)
            {
                Context.Set<Tourist>().Remove(tourist);
            }

            await Context.SaveChangesAsync();
        }
        public async Task UpdateProfileAsync(User user)
        {
            Context.Entry(user).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
