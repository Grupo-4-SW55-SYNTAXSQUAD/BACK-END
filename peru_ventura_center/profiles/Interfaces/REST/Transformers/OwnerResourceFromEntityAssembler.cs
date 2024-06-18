using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Interfaces.REST.Resources;
using peru_ventura_center.publishing.Interfaces.REST.Transformers;

namespace peru_ventura_center.profiles.Interfaces.REST.Transformers
{
    public static class OwnerResourceFromEntityAssembler
    {
        public static OwnerResource ToResourceFromEntity(Owner entity)
        {
            return new OwnerResource(entity.OwnerId,
                UserResourceFromEntityAssembler.ToResourceFromEntity(entity.User),
                PromotionResourceFromEntityAssembler.ToResourceFromEntity(entity.Promotion));
        }
    }
}
