using peru_ventura_center.payments.Domain.Model.Commands;

namespace peru_ventura_center.payments.Domain.Model.Aggregates
{
    public class Booking
    {

        public int booking_state_id { get; set; }
        public string state { get; set; }

        public Booking()
        {
            state = string.Empty;
        }


        public Booking(string estado)
        {
            this.state = state;
        }

        public Booking(CreateBookingCommand reservationStatusCommand)
        {
            this.state = reservationStatusCommand.state;
        }
    }
}
