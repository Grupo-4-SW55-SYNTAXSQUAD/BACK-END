using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Interfaces.REST.Resources;

namespace peru_ventura_center.profiles.Interfaces.REST.Transformers
{
    public static class CreateUserCommandFromResourceAssembler
    {
        public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
        {
            return new CreateUserCommand(
                resource.name,
                resource.email,
                resource.password,
                resource.phone,
                resource.userType);
        }
    }
}
