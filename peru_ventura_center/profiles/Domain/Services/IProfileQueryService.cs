using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.Queries;

namespace peru_ventura_center.profiles.Domain.Services
{
    public interface IProfileQueryService
    {
        Task<IEnumerable<usuario>> Handle(GetAllProfilesQuery query);
        Task<usuario?> Handle(GetProfileByEmailQuery query);
        Task<usuario?> Handle(GetProfileByIdQuery query);
    }
}
