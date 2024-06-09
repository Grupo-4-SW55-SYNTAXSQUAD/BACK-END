namespace peru_ventura_center.Publishing.Domain.Model.Commands
{
    public record CreateActivityCommand(
        string Name, 
        string Description, 
        string Schedule, 
        int MaxPeople, 
        decimal Cost, 
        int CategoryId);
    
}
