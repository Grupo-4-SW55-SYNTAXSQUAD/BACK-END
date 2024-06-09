using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Interfaces.REST.Resources;

namespace peru_ventura_center.payments.Interfaces.REST.Transformers
{
    public static class CreateBookingStateCommandFromResourceAssembler
    {
        public static CreateBookingStateCommand ToCommandFromResource(BookingStateStatusResource resource)
        {
            return new CreateBookingStateCommand(resource.status, resource.booking_states_pk);
        }
    }
}
