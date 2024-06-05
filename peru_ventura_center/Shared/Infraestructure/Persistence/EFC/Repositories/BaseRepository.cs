using peru_ventura_center.Shared.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;

        protected BaseRepository(AppDbContext context) => Context = context;

        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity); // Add an entity to the database

        public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id); // Find an entity by its id

        public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity); // Update an entity in the database

        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity); // Remove an entity from the database

        public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync(); // List all entities in the database
    }
}
