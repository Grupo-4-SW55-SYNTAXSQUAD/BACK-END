using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Model.Commands;


namespace peru_ventura_center.Feedback.Domain.Services
{
    public interface IActivityCommandServices
    {
        Task<Activity?> Handle(CreateActivityCommand command);
        Task<Activity?> Handle(DeleteActivityCommand command);
        Task<Activity?> Handle(PatchActivityCommand command);
    }
}
