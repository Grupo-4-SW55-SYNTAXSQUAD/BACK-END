using Microsoft.EntityFrameworkCore;
using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace peru_ventura_center.Payments.Infrastructure.Persistence.EFC.Repositories
{
    public class PaymentStateRepository(AppDbContext context): BaseRepository<PaymentState>(context), IPaymentStateRepository
    {
        public new async Task<PaymentState?> FindByIdAsync(int PaymentStateId) => await Context.Set<PaymentState>()
            .Where(a => a.PaymentStateId == PaymentStateId).FirstOrDefaultAsync();

        public new async Task<IEnumerable<PaymentState>> ListAsync() => await Context.Set<PaymentState>()
            .ToListAsync();
    }
}
