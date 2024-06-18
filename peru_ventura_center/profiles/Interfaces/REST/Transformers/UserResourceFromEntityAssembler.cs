using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Interfaces.REST.Resources;

namespace peru_ventura_center.profiles.Interfaces.REST.Transformers
{
    public static class UserResourceFromEntityAssembler
    {
        public static UserResource ToResourceFromEntity(User entity)
        {
 
            return new UserResource(entity.UserId,entity.name,entity.email,entity.password,entity.phone,entity.userType);
        }
    }
}
