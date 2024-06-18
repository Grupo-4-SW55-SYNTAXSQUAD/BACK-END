using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Model.Queries;

namespace peru_ventura_center.profiles.Domain.Services
{
    public interface IOwnerQueryService
    {
        Task<Owner?> Handle(GetOwnerByIdQuery query);   // Nuevo método
    }
}
