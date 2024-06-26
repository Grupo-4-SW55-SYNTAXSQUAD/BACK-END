using peru_ventura_center.Feedback.Domain.Model.Aggregates;

namespace peru_ventura_center.Payments.Domain.Model.Aggregates
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public int ActivityId { get; set; }
        public int BookingStateId { get; set; }
        public BookingState BookingState { get; set; }
        public Activity Activity { get; set; }




        public Booking(DateTime BookingDate, int ActivityId, int BookingStateId)
        {
            this.BookingDate = BookingDate;
            this.ActivityId = ActivityId;
            this.BookingStateId = BookingStateId;
        }
        public Booking()
        {
            BookingDate = DateTime.Now;
            Activity = new Activity();
            BookingState = new BookingState();
        }
    }

}
