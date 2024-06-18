using peru_ventura_center.Feedback.Interfaces.REST.Resources;
using peru_ventura_center.Payments.Interfaces.REST.Resources;

namespace peru_ventura_center.profiles.Interfaces.REST.Resources
{
    public record TouristResource(int TouristId,UserResource UserId, ReviewResource ReviewId, BookingResource BookingId);
   
}
