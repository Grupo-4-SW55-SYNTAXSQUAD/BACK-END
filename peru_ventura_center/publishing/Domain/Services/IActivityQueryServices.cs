using peru_ventura_center.Publishing.Domain.Model.Aggregates;
using peru_ventura_center.Publishing.Domain.Model.Queries;

namespace peru_ventura_center.Publishing.Domain.Services
{
    public interface IActivityQueryServices
    {
        Task<Activity?> Handle(GetActivityByIdQuery query);
        Task<IEnumerable<Activity>> Handle(GetAllActivitiesQuery query);
    }
}
