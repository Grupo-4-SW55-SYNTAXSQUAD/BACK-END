
namespace peru_ventura_center.Publishing.Interfaces.REST.Resources
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
