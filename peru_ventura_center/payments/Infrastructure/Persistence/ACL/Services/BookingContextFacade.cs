using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Domain.Model.Queries;
using peru_ventura_center.payments.Domain.Services;


namespace peru_ventura_center.payments.Infrastructure.Persistence.ACL.Services
{
    public class BookingContextFacade(IBookingCommandService bookingCommandService, IBookingQueryService bookingQueryService) : IBookingContextFacade
    {
        public async Task<int> CreateBooking(string state)
        {
            var createBookingCommand = new CreateBookingCommand(state);
            var booking = await bookingCommandService.Handle(createBookingCommand);
            return booking?.booking_id ?? 0;
        }

        public async Task<Booking?> FetchBookingById(int id)
        {
            var getBookingByIdQuery = new GetBookingByIdQuery(id);
            var booking = await bookingQueryService.Handle(getBookingByIdQuery);
            return booking;
        }
    }
}
