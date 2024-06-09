using peru_ventura_center.Publishing.Domain.Model.Aggregates;
using peru_ventura_center.Publishing.Domain.Model.Commands;

namespace peru_ventura_center.Publishing.Domain.Services
{
    public interface IActivityCommandServices
    {
        Task<Activity?> Handle(CreateActivityCommand command);
    }
}
