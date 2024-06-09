using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Model.Commands;
using peru_ventura_center.Feedback.Domain.Model.Queries;
using peru_ventura_center.Feedback.Domain.Services;

namespace peru_ventura_center.Feedback.Infrastructure.Persistence.ACL.Services
{
    public class FeedbackContextFacade(IActivityCommandServices activityCommandServices, IActivityQueryServices activityQueryServices) : IFeedBackContextFacade
    {
        public async Task<int> CreateActivity(string Name, string Description, string Schedule, int MaxPeople, decimal Cost, int CategoryId)
        {
            var createActivityCommand = new CreateActivityCommand( Name,  Description,  Schedule,  MaxPeople,  Cost,  CategoryId);

            var activity = await activityCommandServices.Handle(createActivityCommand);

            return activity?.ActivityId ?? 0;
        }

        public async Task<Activity?> FetchActivityById(int ActivityId)
        {
            var getActivityById= new GetActivityByIdQuery(ActivityId);
            var activity = await activityQueryServices.Handle(getActivityById);
            return activity;
        }
    }
}
