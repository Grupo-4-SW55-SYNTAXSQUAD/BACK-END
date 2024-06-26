using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Interfaces.REST.Resources;
using peru_ventura_center.publishing.Interfaces.REST.Transformers;

namespace peru_ventura_center.profiles.Interfaces.REST.Transformers
{
    public static class OwnerResourceFromEntityAssembler
    {
        public static OwnerResource ToResourceFromEntity(Owner entity)
        {
                //entity.Review != null ? ReviewResourceFromEntityAssembler.ToResourceFromEntity(entity.Review) : null,
            
            return new OwnerResource(entity.OwnerId,
                UserResourceFromEntityAssembler.ToResourceFromEntity(entity.User),
                entity.Promotion!=null ? PromotionResourceFromEntityAssembler.ToResourceFromEntity(entity.Promotion):null
                );
        }
    }
}
