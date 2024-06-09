using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Interfaces.REST.Resources;

namespace peru_ventura_center.Payments.Interfaces.REST.Transformers
{
    public class BookingResourceFromEntityAssembler
    {
        public static BookingResource ToResourceFromEntity(Booking booking)
        {
            return new BookingResource(
                booking.BookingId,
                booking.BookingDate,
                booking.ActivityId,
                booking.BookingStateId
            );
        }
    }
}
