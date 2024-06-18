using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.Entities;

namespace peru_ventura_center.profiles.Domain.Services
{
    public interface ITouristCommandService
    {
        Task<Tourist?> Handle(CreateTouristCommand command); // Nuevo método
    }
}
