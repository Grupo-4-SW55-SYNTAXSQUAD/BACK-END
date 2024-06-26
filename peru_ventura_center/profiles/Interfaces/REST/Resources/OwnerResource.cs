using peru_ventura_center.publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.profiles.Interfaces.REST.Resources
{
    public record OwnerResource(int OwnerId, UserResource User, PromotionResource? Promotion);

}
