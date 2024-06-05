using peru_ventura_center.Shared.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using System;

namespace peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) => _context = context; 

        public async Task CompleteAsync() => await _context.SaveChangesAsync(); // Save changes in the database
    }
}
