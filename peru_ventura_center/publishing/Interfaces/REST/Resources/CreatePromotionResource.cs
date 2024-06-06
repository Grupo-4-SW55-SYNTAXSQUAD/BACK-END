namespace peru_ventura_center.publishing.Interfaces.REST.Resources
{
    public record CreatePromotionResource(
        string name,
        string description,
        int idCommunity, 
        int idTaller,
        string location,
        string horaInicio, 
        string offer, 
        decimal price);

}
