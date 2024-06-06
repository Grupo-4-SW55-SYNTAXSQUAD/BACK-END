namespace peru_ventura_center.publishing.Interfaces.REST.Resources
{
    public record PromotionResource(
        int PromocionId, 
        string name, 
        string description, 
        CommunityResource Community, 
        TallerResource Taller, 
        string location, 
        string horaInicio, 
        string offer, 
        decimal price);
  
}
