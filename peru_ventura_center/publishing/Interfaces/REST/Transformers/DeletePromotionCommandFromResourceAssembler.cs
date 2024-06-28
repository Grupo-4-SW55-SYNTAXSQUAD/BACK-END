using peru_ventura_center.Publishing.Domain.Model.Commands;
using peru_ventura_center.Publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.Publishing.Interfaces.REST.Transformers
{
    public static class DeletePromotionCommandFromResourceAssembler
    {

        public static DeletePromotionCommand ToCommandFromResource(DeletePromotionResource resource){
            return new DeletePromotionCommand(resource.DestinationTripId);
        }
        

        
    }
}
