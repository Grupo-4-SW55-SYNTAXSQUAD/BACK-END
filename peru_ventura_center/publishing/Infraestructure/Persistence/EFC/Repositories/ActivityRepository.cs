﻿using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Publishing.Domain.Model.Aggregates;
using peru_ventura_center.Publishing.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.Publishing.Infraestructure.Persistence.EFC.Repositories
{
    public class ActivityRepository(AppDbContext context) : BaseRepository<Activity>(context),IActivityRepository
    {
        public new async Task<Activity?> FindByIdAsync(int ActivityId) => await Context.Set<Activity>()
            .Include(a => a.Category)
            .Where(a => a.ActivityId == ActivityId).FirstOrDefaultAsync();
        public new async Task<IEnumerable<Activity>> ListAsync() => await Context.Set<Activity>()
            .Include(a => a.Category)
            .ToListAsync();

    }
}
