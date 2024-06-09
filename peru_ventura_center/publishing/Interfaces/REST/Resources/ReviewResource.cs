namespace peru_ventura_center.Publishing.Interfaces.REST.Resources
{
    public record ReviewResource(
        int ReviewId,
        int Score, 
        string Comment,
        ActivityResource Activity
        );
    
}
