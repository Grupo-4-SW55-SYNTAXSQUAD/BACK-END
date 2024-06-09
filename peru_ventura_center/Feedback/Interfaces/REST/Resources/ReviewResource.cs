namespace peru_ventura_center.Feedback.Interfaces.REST.Resources
{
    public record ReviewResource(
        int ReviewId,
        int Score, 
        string Comment,
        ActivityResource Activity
        );
    
}
