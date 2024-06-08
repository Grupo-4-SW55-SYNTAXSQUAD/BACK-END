using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Interfaces.REST.Resources;

namespace peru_ventura_center.profiles.Interfaces.REST.Transformers
{
    public static class CreateProfileCommandFromResourceAssembler
    {
        public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
        {
            return new CreateProfileCommand(resource.nombre,resource.correoElectronico,resource.contrasenia,resource.ubicacion);
        }
    }
}
