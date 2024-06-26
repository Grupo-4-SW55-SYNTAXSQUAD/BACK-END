using peru_ventura_center.Feedback.Interfaces.REST.Transformers;
using peru_ventura_center.Payments.Interfaces.REST.Transformers;
using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Interfaces.REST.Resources;

namespace peru_ventura_center.profiles.Interfaces.REST.Transformers
{
    public static class TouristResourceFromEntityAssembler
    {
        public static TouristResource ToResourceFromEntity(Tourist entity)
        {
            return new TouristResource(entity.TouristId,
                UserResourceFromEntityAssembler.ToResourceFromEntity(entity.User),
                entity.Review != null ? ReviewResourceFromEntityAssembler.ToResourceFromEntity(entity.Review) : null,
                entity.Booking != null ? BookingResourceFromEntityAssembler.ToResourceFromEntity(entity.Booking) : null);
        }
    }
}
