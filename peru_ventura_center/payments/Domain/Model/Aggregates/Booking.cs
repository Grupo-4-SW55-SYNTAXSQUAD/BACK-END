using peru_ventura_center.payments.Domain.Model.Commands;

namespace peru_ventura_center.payments.Domain.Model.Aggregates
{
    public class Booking
    {

        public int booking_id { get; set; }
        public string state { get; set; }

        public Booking()
        {
            state = string.Empty;
        }


        public Booking(string state)
        {
            this.state = this.state;
        }

        public Booking(CreateBookingCommand bookingCommand)
        {
            this.state = bookingCommand.state;
        }
    }
}
