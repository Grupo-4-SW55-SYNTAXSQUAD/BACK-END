namespace peru_ventura_center.Publishing.Domain.Model.Entities
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public DestinationTrip DestinationTrip { get; set; }
        public int DestinationTripId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Offer { get; set; }


        public Promotion(int DestinationTripId, string Name, string Description, string Offer )
        {
            this.DestinationTripId = DestinationTripId;
            this.Name = Name;
            this.Description = Description;
            this.Offer = Offer;
        }

    }
}
