using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace peru_ventura_center.Payments.Infrastructure.Persistence.EFC.Repositories
{
    public class PaymentTypeRepository(AppDbContext context): BaseRepository<PaymentType>(context),IPaymentTypeRepository
    {
        public new async Task<PaymentType?> FindByIdAsync(int PaymentTypeId) => await Context.Set<PaymentType>()
            .Where(a => a.PaymentTypeId == PaymentTypeId).FirstOrDefaultAsync();

        public new async Task<IEnumerable<PaymentType>> ListAsync() => await Context.Set<PaymentType>()
            .ToListAsync();
    }
}

