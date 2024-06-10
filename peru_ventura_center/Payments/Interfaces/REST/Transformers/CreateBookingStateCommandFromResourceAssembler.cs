using peru_ventura_center.Payments.Domain.Model.Commands;
using peru_ventura_center.Payments.Interfaces.REST.Resources;

namespace peru_ventura_center.Payments.Interfaces.REST.Transformers
{
    public static class CreateBookingStateCommandFromResourceAssembler
    {
        public static CreateBookingStateCommand ToCommandFromResource(CreateBookingStateResource resource)
        {
            return new CreateBookingStateCommand(resource.state);
        }
    }
}
