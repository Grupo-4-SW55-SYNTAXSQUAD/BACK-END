namespace peru_ventura_center.Feedback.Domain.Model.Commands
{
    public record CreateReviewCommand(int Score, string Comment, int ActivityId);
    
}
