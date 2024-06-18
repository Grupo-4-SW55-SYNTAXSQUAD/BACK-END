using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Model.Queries;

namespace peru_ventura_center.profiles.Domain.Services
{
    public interface ITouristQueryService
    {
        Task<Tourist?> Handle(GetTouristByIdQuery query); // Nuevo método
    }
}
