using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.Payments.Infrastructure.Persistence.EFC.Repositories
{
    public class PaymentRepository(AppDbContext context) : BaseRepository<Payment>(context),IPaymentRepository
    {
        public new async Task<Payment?> FindByIdAsync(int PaymentId) => await Context.Set<Payment>()
            .Include(a => a.PaymentState)
            .Include(a=>a.PaymentType)
            .Where(a=>a.PaymentId == PaymentId).FirstOrDefaultAsync();
        public new async Task<IEnumerable<Payment>> ListAsync()=> await Context.Set<Payment>()
            .Include(a => a.PaymentState)
            .Include(a => a.PaymentType)
            .ToListAsync();
    }

}
