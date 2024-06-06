namespace peru_ventura_center.publishing.Domain.Model.Commands
{
    public record CreatePromotionCommand(
        string name,
        string description,
        int idCommunity, 
        int idTaller,
        string location,
        string startDate, 
        string offer, 
        decimal price);

}
