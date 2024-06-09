namespace peru_ventura_center.Publishing.Domain.Model.Commands
{
    public record CreateReviewCommand(int Score, string Comment, int ActivityId);
    
}
