using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.Commands;

namespace peru_ventura_center.profiles.Domain.Model.Entities
{
    public class Tourist
    {
        public int TouristId { get; set; }
        public User User { get; set; }
        public Review Review { get; set; }
        public Booking Booking{ get; set; }

        public int UserId { get; set; }
        public int ReviewId { get; set; }
        public int BookingId { get; set; }

        public Tourist()
        {
            UserId = 0;
            ReviewId = 0;
            BookingId = 0;
        }
        public Tourist(int UserId, int ReviewId, int BookingId)
        {
            this.UserId = UserId;
            this.ReviewId = ReviewId;
            this.BookingId = BookingId;
        }
        public Tourist(CreateTouristCommand command)
        {
            UserId= command.UserId;
            ReviewId= command.ReviewId;
            BookingId= command.BookingId;
        }
    }
}
