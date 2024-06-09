namespace peru_ventura_center.Feedback.Interfaces.REST.Resources
{
    public record CreateReviewResource(int Score, string Comment, int ActivityId);

}
