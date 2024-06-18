using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.Entities;

namespace peru_ventura_center.profiles.Domain.Services
{
    public interface IOwnerCommandService
    {
        Task<Owner?> Handle(CreateOwnerCommand command); // Nuevo método
    }
}
