using peru_ventura_center.Feedback.Domain.Model.Commands;
using peru_ventura_center.Feedback.Interfaces.REST.Resources;

namespace peru_ventura_center.Feedback.Interfaces.REST.Transformers
{
    public class PatchActivityCommandFromResourceAssembler
    {
        public static PatchActivityCommand ToCommandFromResource(PatchActivityResource resource)
        {
            return new PatchActivityCommand(resource.ActivityId, resource.name);
        }
    }

}
