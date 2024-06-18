using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Interfaces.REST.Resources;

namespace peru_ventura_center.profiles.Interfaces.REST.Transformers
{
    public static class CreateOwnerCommandFromResourceAssembler
    {
        public static CreateOwnerCommand ToCommandFromResource(CreateOwnerResource resource)
        {
            return new CreateOwnerCommand(resource.UserId,resource.PromotionId );
        }
    }
}
