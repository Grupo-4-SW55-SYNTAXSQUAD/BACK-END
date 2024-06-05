namespace peru_ventura_center.publishing.Domain.Model.Commands
{
    public record CreatePromotionCommand(int idCommunity, int idTaller, string name, string description, TimeSpan startDate, string location, string offer, decimal price);

}
