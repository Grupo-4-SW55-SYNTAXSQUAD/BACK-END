using peru_ventura_center.Feedback.Domain.Model.Queries;
using peru_ventura_center.Feedback.Domain.Services;
using peru_ventura_center.Feedback.Domain.Repositories;
using peru_ventura_center.Feedback.Domain.Model.Aggregates;

namespace peru_ventura_center.Feedback.Application.Internal.QueryServices
{
    public class ActivityQueryServices(IActivityRepository activityRepository):IActivityQueryServices
    {
        public async Task<Activity?> Handle(GetActivityByIdQuery query)
        {
            return await activityRepository.FindByIdAsync(query.ActivityId);
        }
        public async Task<IEnumerable<Activity>> Handle(GetAllActivitiesQuery query)
        {
            return await activityRepository.ListAsync();
        }
    }
}
