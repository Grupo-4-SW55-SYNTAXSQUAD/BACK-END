using peru_ventura_center.Feedback.Domain.Model.Aggregates;

namespace peru_ventura_center.Publishing.Domain.Model.Entities
{
    public class DestinationTrip
    {
        public int DestinationTripId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Activity Activity { get; set; }
        public int ActivityId { get; set; }

        public DestinationTrip(string Name, string Description, string Location, int ActivityId )
        {
            this.Name = Name;
            this.Description = Description;
            this.Location = Location;
            this.ActivityId = ActivityId;
        }
    }
}
