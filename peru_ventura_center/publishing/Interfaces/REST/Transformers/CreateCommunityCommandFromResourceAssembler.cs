using peru_ventura_center.publishing.Domain.Model.Commands;
using peru_ventura_center.publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.publishing.Interfaces.REST.Transformers
{
    public static class CreateCommunityCommandFromResourceAssembler
    {
        public static CreateCommunitiyCommand ToCommandFromResource(CreateCommunityResource resource)
        {
            return new CreateCommunitiyCommand(
                               resource.name,
                               resource.description,
                               resource.culture);
        }
    }
}
