using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.Commands;

namespace peru_ventura_center.profiles.Domain.Services
{
    public interface IProfileCommandService
    {
        Task<usuario?> Handle(CreateProfileCommand command);
    }
}
