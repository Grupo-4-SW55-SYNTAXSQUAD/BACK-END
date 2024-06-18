﻿using peru_ventura_center.profiles.Domain.Model.ValueObjects;
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
    }
}
