
namespace peru_ventura_center.Feedback.Interfaces.REST.Resources
{
    public record ActivityResource(
            int ActivityId,
            string Name, 
            string Description, 
            string Schedule, 
            int MaxPeople, 
            decimal Cost, 
            CategoryResource Category
        ); 
}
