namespace peru_ventura_center.publishing.Interfaces.REST.Resources
{
    public record PromotionResource(int Id, string name, string description, CommunityResource Community, TallerResource Taller, string location, TimeSpan schedule, string offer, decimal price);
  
}
