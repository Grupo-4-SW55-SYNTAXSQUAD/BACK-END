using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Interfaces.REST.Resources;

namespace peru_ventura_center.profiles.Interfaces.REST.Transformers
{
    public static class ProfileResourceFromEntityAssembler
    {
        public static ProfileResource ToResourceFromEntity(usuario entity)
        {
            if (entity == null)
            {
                Console.WriteLine("La entidad usuario es null en ToResourceFromEntity.");
                return null;
            }
            return new ProfileResource(entity.UsuarioId,entity.nombre,entity.correoElectronico,entity.contrasenia,entity.ubicacion);
        }
    }
}
