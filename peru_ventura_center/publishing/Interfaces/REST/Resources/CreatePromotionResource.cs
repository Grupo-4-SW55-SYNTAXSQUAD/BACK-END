namespace peru_ventura_center.publishing.Interfaces.REST.Resources
{
    public record CreatePromotionResource(int idCommunity, int idTaller, string name, string description, TimeSpan startDate, string location, string offer, decimal price);

}
