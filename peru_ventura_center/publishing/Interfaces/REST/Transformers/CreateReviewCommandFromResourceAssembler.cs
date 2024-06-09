using peru_ventura_center.Publishing.Domain.Model.Commands;
using peru_ventura_center.Publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.Publishing.Interfaces.REST.Transformers
{
    public class CreateReviewCommandFromResourceAssembler
    {
        public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource)
        {
            return new CreateReviewCommand(
                    resource.Score,
                    resource.Comment,
                    resource.ActivityId
                );
        }
    }
}
