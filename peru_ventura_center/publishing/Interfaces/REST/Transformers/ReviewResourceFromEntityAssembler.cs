using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.Publishing.Interfaces.REST.Transformers
{
    public class ReviewResourceFromEntityAssembler
    {
        public static ReviewResource ToResourceFromEntity(Review activity)
        {
            return new ReviewResource(
                    activity.ReviewId,
                    activity.Score,
                    activity.Comment,
                    ActivityResourceFromEntityAssembler.ToResourceFromEntity(activity.Activity)
                );
        }
    }
}
