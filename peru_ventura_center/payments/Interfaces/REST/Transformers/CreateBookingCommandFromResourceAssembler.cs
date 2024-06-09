using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Interfaces.REST.Resources;

namespace peru_ventura_center.payments.Interfaces.REST.Transformers
{
    public static class CreateBookingCommandFromResourceAssembler
    {
        public static CreateBookingCommand ToCommandFromResource(BookingResource resource)
        {
            return new CreateBookingCommand(resource.status);
        }
    }
}
