using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Interfaces.REST.Resources;

namespace peru_ventura_center.payments.Interfaces.REST.Transformers
{
    public static class CreateBookingStateCommandFromResourceAssembler
    {
        public static CreateBookingStateCommand ToCommandFromResource(CreateBookingStateResource resource)
        {
            return new CreateBookingStateCommand(resource.state);
        }
    }
}
