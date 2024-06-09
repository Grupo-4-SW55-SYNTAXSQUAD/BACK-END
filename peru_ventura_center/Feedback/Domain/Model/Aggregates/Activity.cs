namespace peru_ventura_center.Feedback.Domain.Model.Aggregates
{

    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }
        public int MaxPeople { get; set; }
        public decimal Cost { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Activity(string Name, string Description, string Schedule, int MaxPeople, decimal Cost, int CategoryId)
        {
            
            this.Name = Name;
            this.Description = Description;
            this.Schedule = Schedule;
            this.MaxPeople = MaxPeople;
            this.Cost = Cost;
            this.CategoryId = CategoryId;
        }

    }
}
