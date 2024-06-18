using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Model.Queries;

namespace peru_ventura_center.profiles.Domain.Services
{
    public interface IUserQueryService
    {
        Task<IEnumerable<User>> Handle(GetAllProfilesQuery query);
        Task<User?> Handle(GetUserByEmailQuery query);
        Task<User?> Handle(GetUserByIdQuery query);
    }
}
