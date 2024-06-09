using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.Feedback.Infraestructure.Persistence.EFC.Repositories
{
    public class ReviewRepository(AppDbContext context) : BaseRepository<Review>(context),IReviewRepository
    {
        public new async Task<Review?> FindByIdAsync(int ReviewId) => await Context.Set<Review>()
            .Include(r => r.Activity)
            .Include(r => r.Activity.Category)
            .Where(r => r.ReviewId == ReviewId).FirstOrDefaultAsync();
        public new async Task<IEnumerable<Review>> ListAsync() => await Context.Set<Review>()
            .Include(r => r.Activity)
            .Include(r=> r.Activity.Category)
            .ToListAsync();
    }
}
