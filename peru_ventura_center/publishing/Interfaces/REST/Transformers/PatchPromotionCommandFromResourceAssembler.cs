using peru_ventura_center.Publishing.Domain.Model.Commands;
using peru_ventura_center.Publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.Publishing.Interfaces.REST.Transformers
{
    public class PatchPromotionCommandFromResourceAssembler
    {

        public static PatchPromotionCommand ToCommandFromResource(PatchPromotionResource resource)
        {
            return new PatchPromotionCommand(resource.DestinationTripId, resource.name);
        }
    }
}
