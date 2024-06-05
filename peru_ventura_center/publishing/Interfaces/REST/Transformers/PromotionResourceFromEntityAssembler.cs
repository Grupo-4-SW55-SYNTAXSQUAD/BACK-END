using peru_ventura_center.publishing.Domain.Model.Aggregates;
using peru_ventura_center.publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.publishing.Interfaces.REST.Transformers
{
    public static class PromotionResourceFromEntityAssembler
    {
        public static PromotionResource ToResourceFromEntity (promociones promotions)
        {
            return new PromotionResource(
                promotions.PromocionId,
                promotions.nombre,
                promotions.descripcion,
                CommunityResourceFromEntityAssembler.ToResourceFromEntity(promotions.Comunidad),
                TallerResourceFromEntityAssembler.ToResourceFromEntity
                (promotions.Taller),
                promotions.ubicacion,
                promotions.horaInicio,
                promotions.oferta,
                promotions.precio);
        }
    }
}
