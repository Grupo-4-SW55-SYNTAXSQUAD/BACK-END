using peru_ventura_center.Publishing.Domain.Model.Aggregates;
using peru_ventura_center.Publishing.Domain.Model.Queries;
using peru_ventura_center.Publishing.Domain.Repositories;
using peru_ventura_center.Publishing.Domain.Services;

namespace peru_ventura_center.Publishing.Application.Internal.QueryServices
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
