using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Interfaces.REST.Resources;

namespace peru_ventura_center.Payments.Interfaces.REST.Transformers
{
    public static class BookingStateResourceFromEntityAssembler
    {

        public static BookingStateResource ToResourceFromEntity(BookingState entity)
        {
            if (entity == null)
            {
                Console.WriteLine("La entidad usuario es null en ToResourceFromEntity.");
                return null;
            }
            return new BookingStateResource(entity.booking_state_id, entity.state);
        }
    }
}
