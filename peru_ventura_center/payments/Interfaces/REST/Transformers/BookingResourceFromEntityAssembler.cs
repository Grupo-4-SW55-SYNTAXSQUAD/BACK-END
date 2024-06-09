using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Interfaces.REST.Resources;

namespace peru_ventura_center.payments.Interfaces.REST.Transformers
{
    public static class BookingResourceFromEntityAssembler
    {

        public static BookingResource ToResourceFromEntity(Booking entity)
        {
            if (entity == null)
            {
                Console.WriteLine("La entidad usuario es null en ToResourceFromEntity.");
                return null;
            }
            return new BookingStateStatusResource(entity.booking_state_id);
        }
    }
}
