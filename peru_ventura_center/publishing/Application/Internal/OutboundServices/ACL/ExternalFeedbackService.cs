using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Infrastructure.Persistence.ACL;
using peru_ventura_center.Publishing.Domain.Model.ValueObjects;

namespace peru_ventura_center.Publishing.Application.Internal.OutboundServices.ACL
{
    public class ExternalFeedbackService(IFeedBackContextFacade feedBackContextFacade)
    {
        public async Task<Activity?> FetchActivityById(int ActivityId)
        {
            var activity = await feedBackContextFacade.FetchActivityById(ActivityId);
            if (activity == null) return await Task.FromResult<Activity?>(null);
            return activity;
        }   
        public async Task<ActivityId?> CreateActivity(string Name, string Description, string Schedule, int MaxPeople, decimal Cost, int CategoryId)
        {
            var activityId = await feedBackContextFacade.CreateActivity(Name,Description,Schedule, MaxPeople, Cost,CategoryId);
            if (activityId == 0) return await Task.FromResult<ActivityId?>(null);
            return new ActivityId(activityId);
        }

    
    }
}
