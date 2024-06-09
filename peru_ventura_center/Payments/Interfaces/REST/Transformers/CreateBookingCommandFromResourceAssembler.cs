using peru_ventura_center.Payments.Domain.Model.Commands;
using peru_ventura_center.Payments.Interfaces.REST.Resources;

namespace peru_ventura_center.Payments.Interfaces.REST.Transformers
{
    public class CreateBookingCommandFromResourceAssembler
    {
        public static CreateBookingCommand ToCommandFromResource(CreateBookingResource resource)
        {
            return new CreateBookingCommand(
                    resource.BookingDate,
                    resource.ActivityId,
                    resource.BookingStateId
            );
        }
    }
}
