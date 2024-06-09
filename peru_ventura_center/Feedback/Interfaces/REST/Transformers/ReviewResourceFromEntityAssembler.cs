using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Interfaces.REST.Resources;

namespace peru_ventura_center.Feedback.Interfaces.REST.Transformers
{
    public class ReviewResourceFromEntityAssembler
    {
        public static ReviewResource ToResourceFromEntity(Review review)
        {
            return new ReviewResource(
                    review.ReviewId,
                    review.Score,
                    review.Comment,
                    ActivityResourceFromEntityAssembler.ToResourceFromEntity(review.Activity)
                );
        }
    }
}
