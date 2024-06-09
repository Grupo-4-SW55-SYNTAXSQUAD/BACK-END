﻿using peru_ventura_center.payments.Domain.Model.Commands;

namespace peru_ventura_center.payments.Domain.Model.Aggregates
{
    public class BookingState
    {

        public int booking_state_id { get; set; }
        public string state { get; set; }
        public int booking_states_pk { get; set; }

        public BookingState()
        {
            state = string.Empty;
        }


        public BookingState(string estado)
        {
            this.state = state;
        }

        public BookingState(CreateBookingStateCommand reservationStatusCommand)
        {
            this.state = reservationStatusCommand.state;
        }
    }
}
