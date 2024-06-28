using peru_ventura_center.Feedback.Domain.Model.Commands;
using peru_ventura_center.Feedback.Interfaces.REST.Resources;
using peru_ventura_center.publishing.Infrastructure.Persistence.ACL.Services;

namespace peru_ventura_center.Feedback.Interfaces.REST.Transformers
{
    public static class DeleteActivityCommandFromResourceAssembler
    {

       public static DeleteActivityCommand ToCommandFromResource(DeleteActivityResource resource) {
            return new DeleteActivityCommand(resource.ActivityId);
        }

    }
}
