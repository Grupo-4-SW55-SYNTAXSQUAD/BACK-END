using peru_ventura_center.Feedback.Domain.Model.Commands;
using peru_ventura_center.Feedback.Interfaces.REST.Resources;

namespace peru_ventura_center.Feedback.Interfaces.REST.Transformers
{
    public class CreateActivityCommandFromResourceAssembler
    {
        public static CreateActivityCommand ToCommandFromResource(CreateActivityResource resource)
        {
            return new CreateActivityCommand(
                    resource.Name,
                    resource.Description,
                    resource.Schedule,
                    resource.MaxPeople,
                    resource.Cost,
                    resource.CategoryId

                );
        }
    }
}
