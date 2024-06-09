using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.Feedback.Infraestructure.Persistence.EFC.Repositories
{
    public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context), ICategoryRepository
    {
        public new async Task<Category?> FindByIdAsync(int CategoryId) => await Context.Set<Category>()
                    .Where(a => a.CategoryId == CategoryId).FirstOrDefaultAsync();
        public new async Task<IEnumerable<Category>> ListAsync() => await Context.Set<Category>()
            .ToListAsync();
    }
}
