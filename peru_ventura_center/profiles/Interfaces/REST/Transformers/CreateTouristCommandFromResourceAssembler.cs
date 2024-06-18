using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Interfaces.REST.Resources;

namespace peru_ventura_center.profiles.Interfaces.REST.Transformers
{
    public static class CreateTouristCommandFromResourceAssembler
    {
        public static CreateTouristCommand ToCommandFromResource(CreateTouristResource resource)
        {
            return new CreateTouristCommand(resource.UserId,resource.ReviewId,resource.BookingId);
        }
    }
}
