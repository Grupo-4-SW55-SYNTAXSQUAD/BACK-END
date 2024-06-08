using peru_ventura_center.profiles.Interfaces.REST.Transformers;
using peru_ventura_center.publishing.Domain.Model.Entities;
using peru_ventura_center.publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.publishing.Interfaces.REST.Transformers
{
    public static class TallerResourceFromEntityAssembler
    {
        public static TallerResource ToResourceFromEntity(Taller entity)
        {
            return new TallerResource(entity.TallerId,entity.nombre,entity.descripcion,entity.ubicacion,entity.horario,entity.cupoMaximo,entity.medidaSeguridad,
                CommunityResourceFromEntityAssembler.ToResourceFromEntity(entity.Comunidad),
                ProfileResourceFromEntityAssembler.ToResourceFromEntity(entity.Usuario));
        }
    }
}
