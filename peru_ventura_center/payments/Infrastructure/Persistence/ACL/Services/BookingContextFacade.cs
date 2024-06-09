using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Domain.Model.Queries;
using peru_ventura_center.payments.Domain.Services;


namespace peru_ventura_center.payments.Infrastructure.Persistence.ACL.Services
{
    public class BookingContextFacade(IBookingCommandService bookingStateCommandService, IBookingQueryService bookingStateQueryService) : IBookingContextFacade
    {
        public async Task<int> CreateReservationStatus(string state)
        {
            var createReservationStatusCommand = new CreateBookingCommand(state);
            var bookingState = await bookingStateCommandService.Handle(createReservationStatusCommand);
            return bookingState?.booking_state_id ?? 0;
        }

        public async Task<Booking?> FetchReservationStatusById(int id)
        {
            var getBookingStateByIdQuery = new GetBookingByIdQuery(id);
            var bookingState = await bookingStateQueryService.Handle(getBookingStateByIdQuery);
            return bookingState;
        }
    }
}
