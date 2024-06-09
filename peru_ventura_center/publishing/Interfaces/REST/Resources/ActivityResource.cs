
namespace peru_ventura_center.Publishing.Interfaces.REST.Resources
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
