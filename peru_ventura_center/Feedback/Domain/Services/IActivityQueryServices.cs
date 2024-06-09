using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Model.Queries;

namespace peru_ventura_center.Feedback.Domain.Services
{
    public interface IActivityQueryServices
    {
        Task<Activity?> Handle(GetActivityByIdQuery query);
        Task<IEnumerable<Activity>> Handle(GetAllActivitiesQuery query);
    }
}
