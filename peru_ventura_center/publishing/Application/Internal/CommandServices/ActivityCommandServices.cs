using peru_ventura_center.Publishing.Domain.Model.Aggregates;
using peru_ventura_center.Publishing.Domain.Model.Commands;
using peru_ventura_center.Publishing.Domain.Repositories;
using peru_ventura_center.Publishing.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.Publishing.Application.Internal.CommandServices
{
    public class ActivityCommandServices(IActivityRepository activityRepository, IUnitOfWork unitOfWork):IActivityCommandServices
    {
        public async Task<Activity?> Handle(CreateActivityCommand command)
        {

            var activity = new Activity(command.Name, command.Description, command.Schedule, command.MaxPeople, command.Cost, command.CategoryId); // Create a new Activity
            await activityRepository.AddAsync(activity); // Add the new Activity to the repository
            await unitOfWork.CompleteAsync(); // Save the changes
            return activity;
        }
    }
}
