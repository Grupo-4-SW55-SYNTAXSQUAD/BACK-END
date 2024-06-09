
namespace peru_ventura_center.Feedback.Interfaces.REST.Resources
{
    public record CreateActivityResource(
            string Name,
            string Description,
            string Schedule,
            int MaxPeople,
            decimal Cost,
            int CategoryId
        );

}
