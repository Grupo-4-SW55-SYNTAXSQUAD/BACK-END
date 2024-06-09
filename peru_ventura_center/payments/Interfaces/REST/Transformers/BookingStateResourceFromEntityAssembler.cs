using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Interfaces.REST.Resources;

namespace peru_ventura_center.payments.Interfaces.REST.Transformers
{
    public static class BookingStateResourceFromEntityAssembler
    {

        public static BookingStateStatusResource ToResourceFromEntity(BookingState entity)
        {
            if (entity == null)
            {
                Console.WriteLine("La entidad usuario es null en ToResourceFromEntity.");
                return null;
            }
            return new BookingStateStatusResource(entity.booking_state_id, entity.state, entity.booking_states_pk);
        }
    }
}
