using peru_ventura_center.publishing.Domain.Model.Entities;
using peru_ventura_center.publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.publishing.Interfaces.REST.Transformers
{
    public static class CommunityResourceFromEntityAssembler
    {
        public static CommunityResource ToResourceFromEntity(comunidad entity)
        {
            return new CommunityResource(entity.ComunidadId,entity.nombre,entity.descripcion,entity.cultura);
        }
    }
}
