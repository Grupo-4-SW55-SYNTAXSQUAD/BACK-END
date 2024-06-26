using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.Profiles.Interfaces.REST.Resources;

namespace peru_ventura_center.Profiles.Interfaces.REST.Transformers
{
    public static class PatchUserCommandFromResourceAssembler
    {
        public static void ApplyPatch(User user, PatchUserResource resource)
        {
            //Patch
            user.Patch(resource.name, resource.email, resource.phone,resource.password);
        }
    }
}
