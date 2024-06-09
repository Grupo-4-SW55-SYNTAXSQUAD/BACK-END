using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Domain.Model.Queries;
using peru_ventura_center.payments.Domain.Services;


namespace peru_ventura_center.payments.Infrastructure.Persistence.ACL.Services
{
    public class BookingStateContextFacade(IBookingStateCommandService bookingStateCommandService, IBookingStateQueryService bookingStateQueryService) : IBookingStateContextFacade
    {
        public async Task<int> CreateBooking(string state)
        {
            var createBookingStateCommand = new CreateBookingStateCommand(state);
            var bookingState = await bookingStateCommandService.Handle(createBookingStateCommand);
            return bookingState?.booking_state_id ?? 0;
        }

        public async Task<BookingState?> FetchBookingById(int id)
        {
            var getBookingStateByIdQuery = new GetBookingStateByIdQuery(id);
            var bookingState = await bookingStateQueryService.Handle(getBookingStateByIdQuery);
            return bookingState;
        }
    }
}
