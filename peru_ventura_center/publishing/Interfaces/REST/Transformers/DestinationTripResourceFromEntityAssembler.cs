using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.Publishing.Interfaces.REST.Transformers
{
    public static class DestinationTripResourceFromEntityAssembler
    {
        public static DestinationTripResource ToResourceFromEntity(DestinationTrip destinationTrip)
        {
            return new DestinationTripResource(
                       destinationTrip.DestinationTripId,
                       destinationTrip.Name,
                       destinationTrip.Description,
                       destinationTrip.Location,
                       ActivityResourceFromEntityAssembler.ToResourceFromEntity(destinationTrip.Activity)
                                                                                                                                   );
        }
    }
}
