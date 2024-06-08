using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.ValueObjects;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.profiles.Domain.Repositories
{
    public interface IProfileRepository:IBaseRepository<usuario>
    {
        Task<usuario?> FindProfileByEmailAsync(EmailAddress email);
    }
}
