﻿using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.profiles.Domain.Repositories
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<User?> FindProfileByEmailAsync(string email);
        Task DeleteProfileAsync(User user);
        Task UpdateProfileAsync(User user);
    }
}
